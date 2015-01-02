using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.Net;
namespace AsyncSocket
{
    // Implements the connection logic for the socket server.   
    // After accepting a connection, all data read from the client  
    // is sent back to the client. The read and echo back to the client pattern  
    // is continued until the client disconnects. 
    class Server
    {
        /// <summary>
        /// 能同时处理的最大连接数
        /// </summary>
        private int m_numConnections;   // the maximum number of connections the sample is designed to handle simultaneously  
        /// <summary>
        /// 接收缓冲区大小
        /// </summary>
        private int m_receiveBufferSize;// buffer size to use for each socket I/O operation 

        /// <summary>
        /// 给所有套接字分配的buffer管理
        /// </summary>
        BufferManager m_bufferManager;  // represents a large reusable set of buffers for all socket operations 

        /// <summary>
        /// 读写
        /// </summary>
        const int opsToPreAlloc = 2;    // read, write (don't alloc buffer space for accepts)不给接受的分配缓冲区

        /// <summary>
        /// 监听套接字
        /// </summary>
        Socket listenSocket;            // the socket used to listen for incoming connection requests 
        // pool of reusable SocketAsyncEventArgs objects for write, read and accept socket operations
        SocketAsyncEventArgsPool m_readWritePool;

        /// <summary>
        /// 读取到的字节数
        /// </summary>
        int m_totalBytesRead;           // counter of the total # bytes received by the server 

        /// <summary>
        /// 连接在服务端的客户端数量
        /// </summary>
        int m_numConnectedSockets;      // the total number of clients connected to the server 

        /// <summary>
        /// 信号
        /// </summary>
        Semaphore m_maxNumberAcceptedClients;

        // Create an uninitialized server instance.   
        // To start the server listening for connection requests 
        // call the Init method followed by Start method  
        // 
        // <param name="numConnections">the maximum number of connections the sample is designed to handle simultaneously</param>
        // <param name="receiveBufferSize">buffer size to use for each socket I/O operation</param>
        public Server(int numConnections, int receiveBufferSize)
        {
            m_totalBytesRead = 0;
            m_numConnectedSockets = 0;
            m_numConnections = numConnections;
            m_receiveBufferSize = receiveBufferSize;
            // allocate buffers such that the maximum number of sockets can have one outstanding read and  
            //write posted to the socket simultaneously  
            m_bufferManager = new BufferManager(receiveBufferSize * numConnections * opsToPreAlloc,
                receiveBufferSize * opsToPreAlloc);//单个套接字的缓冲区大小，也需要* opsToPreAlloc，否则只用了1/opsToPreAlloc的空间

            m_readWritePool = new SocketAsyncEventArgsPool(numConnections);
            m_maxNumberAcceptedClients = new Semaphore(numConnections, numConnections);
        }

        // Initializes the server by preallocating reusable buffers and  
        // context objects.  These objects do not need to be preallocated  
        // or reused, but it is done this way to illustrate how the API can  
        // easily be used to create reusable objects to increase server performance. 
        // 
        public void Init()
        {
            // Allocates one large byte buffer which all I/O operations use a piece of.  This gaurds  
            // against memory fragmentation
            m_bufferManager.InitBuffer();

            // preallocate pool of SocketAsyncEventArgs objects
            SocketAsyncEventArgs readWriteEventArg;

            //创建m_numConnections套接字，压入m_readWritePool中备用，需要的时候就Pop
            for (int i = 0; i < m_numConnections; i++)
            {
                //Pre-allocate a set of reusable SocketAsyncEventArgs
                readWriteEventArg = new SocketAsyncEventArgs();
                //绑定Completed事件
                readWriteEventArg.Completed += new EventHandler<SocketAsyncEventArgs>(IO_Completed);
                readWriteEventArg.UserToken = new AsyncUserToken();

                // assign a byte buffer from the buffer pool to the SocketAsyncEventArg object
                //给每一个新创建的异步套接字分配缓存区
                m_bufferManager.SetBuffer(readWriteEventArg);

                // add SocketAsyncEventArg to the pool
                m_readWritePool.Push(readWriteEventArg);
            }

        }

        // Starts the server such that it is listening for  
        // incoming connection requests.     
        // 
        // <param name="localEndPoint">The endpoint which the server will listening 
        // for connection requests on</param> 
        public void Start(IPEndPoint localEndPoint)
        {
            try
            {
                // create the socket which listens for incoming connections
                listenSocket = new Socket(localEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                listenSocket.Bind(localEndPoint);
                // start the server with a listen backlog of 100 connections
                listenSocket.Listen(100);

                // post accepts on the listening socket
                StartAccept(null);

                //Console.WriteLine("{0} connected sockets with one outstanding receive posted to each....press any key", m_outstandingReadCount);
                Console.WriteLine("Press any key to stop the server");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // Begins an operation to accept a connection request from the client  
        // 
        // <param name="acceptEventArg">The context object to use when issuing 
        // the accept operation on the server's listening socket</param> 
        public void StartAccept(SocketAsyncEventArgs acceptEventArg)
        {
            if (acceptEventArg == null)
            {
                acceptEventArg = new SocketAsyncEventArgs();
                acceptEventArg.Completed += new EventHandler<SocketAsyncEventArgs>(AcceptEventArg_Completed);
            }
            else
            {
                // socket must be cleared since the context object is being reused
                acceptEventArg.AcceptSocket = null;
            }

            m_maxNumberAcceptedClients.WaitOne();
            //AcceptAsync异步接受客户端的连接,有客户端连接上来的时候,会触发acceptEvent.ArgCompleted事件
            //即为本文件中的AcceptEventArg_Completed函数
            bool willRaiseEvent = listenSocket.AcceptAsync(acceptEventArg);
            if (!willRaiseEvent)
            {
                ProcessAccept(acceptEventArg);
            }
        }

        // This method is the callback method associated with Socket.AcceptAsync  
        // operations and is invoked when an accept operation is complete 
        // 
        void AcceptEventArg_Completed(object sender, SocketAsyncEventArgs e)
        {
            ProcessAccept(e);
        }

        private void ProcessAccept(SocketAsyncEventArgs e)
        {
            Interlocked.Increment(ref m_numConnectedSockets);
            Console.WriteLine("[{1}]  Client connection accepted. There are {0} clients connected to the server",
                m_numConnectedSockets, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            // Get the socket for the accepted client connection and put it into the  
            //ReadEventArg object user token
            SocketAsyncEventArgs readEventArgs = m_readWritePool.Pop();
            ((AsyncUserToken)readEventArgs.UserToken).Socket = e.AcceptSocket;

            // As soon as the client is connected, post a receive to the connection 
            //ReceiveAsync异步的接收数据,有数据过来的时候，会触发readEventArgs的Completed事件,即为本文件中的函数IO_Completed
            bool willRaiseEvent = e.AcceptSocket.ReceiveAsync(readEventArgs);
            if (!willRaiseEvent)
            {
                ProcessReceive(readEventArgs);
            }

            // Accept the next connection request
            //接受下一个连接请求
            StartAccept(e);
        }

        // This method is called whenever a receive or send operation is completed on a socket  
        // 
        // <param name="e">SocketAsyncEventArg associated with the completed receive operation</param>
        void IO_Completed(object sender, SocketAsyncEventArgs e)
        {
            // determine which type of operation just completed and call the associated handler 
            switch (e.LastOperation)
            {
                case SocketAsyncOperation.Receive:
                    ProcessReceive(e);
                    break;
                case SocketAsyncOperation.Send:
                    ProcessSend(e);
                    break;
                default:
                    throw new ArgumentException("The last operation completed on the socket was not a receive or send");
            }

        }

        // This method is invoked when an asynchronous receive operation completes.  
        // If the remote host closed the connection, then the socket is closed.   
        // If data was received then the data is echoed back to the client. 
        // 
        private void ProcessReceive(SocketAsyncEventArgs e)
        {
            // check if the remote host closed the connection
            AsyncUserToken token = (AsyncUserToken)e.UserToken;
            if (e.BytesTransferred > 0 && e.SocketError == SocketError.Success)
            {
                //increment the count of the total bytes receive by the server
                Interlocked.Add(ref m_totalBytesRead, e.BytesTransferred);
                Console.WriteLine("[{1}]  The server has read a total of {0} bytes", 
                    m_totalBytesRead, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                //echo the data received back to the client
                //无需调整缓冲区的大小,目前默认的缓冲区大小为10,
                //如果第一次发送的字节数为7，将缓冲区空间设置为10之后，会导致下一次最多只能接收7个字节
                //如果第二次发10个字节的，会分成两次接收，先接收7字节，再接收另外的3字节
                //e.SetBuffer(e.Offset, e.BytesTransferred);
                bool willRaiseEvent = token.Socket.SendAsync(e);
                if (!willRaiseEvent)
                {
                    ProcessSend(e);
                }

            }
            else
            {
                CloseClientSocket(e);//接收出错的时候关闭套接字[客户端主动断开连接]
            }

        }





        // This method is invoked when an asynchronous send operation completes.   
        // The method issues another receive on the socket to read any additional  
        // data sent from the client 
        // 
        // <param name="e"></param>
        private void ProcessSend(SocketAsyncEventArgs e)
        {
            if (e.SocketError == SocketError.Success)
            {
                // done echoing data back to the client
                AsyncUserToken token = (AsyncUserToken)e.UserToken;
                // read the next block of data send from the client 
                bool willRaiseEvent = token.Socket.ReceiveAsync(e);
                if (!willRaiseEvent)
                {
                    ProcessReceive(e);
                }
            }
            else
            {
                CloseClientSocket(e);//发送出错的时候，关闭套接字[客户端主动断开连接]
            }
        }

        private void CloseClientSocket(SocketAsyncEventArgs e)
        {
            AsyncUserToken token = e.UserToken as AsyncUserToken;

            // close the socket associated with the client 
            try
            {
                //禁用发送
                token.Socket.Shutdown(SocketShutdown.Send);
            }
            // throws if client process has already closed 
            catch (Exception) { }
            token.Socket.Close();

            // decrement the counter keeping track of the total number of clients connected to the server
            Interlocked.Decrement(ref m_numConnectedSockets);

            m_maxNumberAcceptedClients.Release();
            Console.WriteLine(@"[{0}]  A client has been disconnected from the server. 
            There are {1} clients connected to the server", 
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),m_numConnectedSockets);

            // Free the SocketAsyncEventArg so they can be reused by another client
            m_readWritePool.Push(e);//将空闲的套接字压入m_readWritePool
        }

    }    
}
