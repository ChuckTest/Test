using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
namespace AsyncSocket
{
    class BufferManager
    {
        /// <summary>
        /// m_buffer初始化的时候的大小，是所有套接字缓冲区字节数的总和
        /// </summary>
        int m_numBytes;                 // the total number of bytes controlled by the buffer pool

        /// <summary>
        /// 所有的套接字的缓冲区都从这里分配
        /// </summary>
        byte[] m_buffer;                // the underlying byte array maintained by the Buffer Manager

        /// <summary>
        /// 记录空闲的公共缓冲区
        /// </summary>
        Stack<int> m_freeIndexPool;     

        /// <summary>
        /// 当前已经分配给套接字的缓冲区字节数
        /// </summary>
        int m_currentIndex;

        /// <summary>
        /// 每个套接字的缓冲区大小
        /// </summary>
        int m_bufferSize;


        public BufferManager(int totalBytes, int bufferSize)
        {
            m_numBytes = totalBytes;
            m_currentIndex = 0;
            m_bufferSize = bufferSize;
            m_freeIndexPool = new Stack<int>();
        }

        // Allocates buffer space used by the buffer pool 
        public void InitBuffer()
        {
            // create one big large buffer and divide that  
            // out to each SocketAsyncEventArg object
            m_buffer = new byte[m_numBytes];
        }

        /// <summary>
        /// 给特定的套接字，分配缓冲区
        /// </summary>
        /// <param name="args">待分配缓冲区的套接字</param>
        /// <returns></returns>
        public bool SetBuffer(SocketAsyncEventArgs args)
        {
            if (m_freeIndexPool.Count > 0)//如果buffer数组有空闲的空间
            {
                //将buffer数组中,从m_freeIndexPool.Pop()开始，计数m_bufferSize大小的空间，分配给套接字
                args.SetBuffer(m_buffer, m_freeIndexPool.Pop(), m_bufferSize);
            }
            else
            {
                if ((m_numBytes - m_bufferSize) < m_currentIndex)//缓冲区剩余的空间不足以存放m_bufferSize大小的字符串
                {
                    return false;//分配空间失败
                }
                //将buffer数组中,从m_currentIndex开始，计数m_bufferSize大小的空间，分配给套接字
                args.SetBuffer(m_buffer, m_currentIndex, m_bufferSize);
                //将计数增加
                m_currentIndex += m_bufferSize;
            }
            return true;
        }

        // Removes the buffer from a SocketAsyncEventArg object.   
        // This frees the buffer back to the buffer pool 
        public void FreeBuffer(SocketAsyncEventArgs args)
        {
            //获取args套接字占用的buffer空间的起始位置
            m_freeIndexPool.Push(args.Offset);
            //清除args套接字缓冲区和buffer数组的关联
            args.SetBuffer(null, 0, 0);
        }
    }
}
