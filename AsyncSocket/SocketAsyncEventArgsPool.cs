using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
namespace AsyncSocket
{
    class SocketAsyncEventArgsPool
    {
        /// <summary>
        /// 套接字栈
        /// </summary>
        Stack<SocketAsyncEventArgs> m_pool;

        /// <summary>
        /// 初始化套接字栈
        /// </summary>
        /// <param name="capacity">m_pool中可以存放的套接字的上限</param>
        public SocketAsyncEventArgsPool(int capacity)
        {
            m_pool = new Stack<SocketAsyncEventArgs>(capacity);
        }

        /// <summary>
        /// 将异步套接字实例压入m_pool
        /// </summary>
        /// <param name="item"></param>
        public void Push(SocketAsyncEventArgs item)
        {
            if (item == null) { throw new ArgumentNullException("Items added to a SocketAsyncEventArgsPool cannot be null"); }
            lock (m_pool)
            {
                m_pool.Push(item);
            }
        }

        /// <summary>
        /// 从栈顶取出一个异步套接字，并移除
        /// </summary>
        /// <returns></returns>
        public SocketAsyncEventArgs Pop()
        {
            lock (m_pool)
            {
                return m_pool.Pop();
            }
        }

        /// <summary>
        /// 异步套接字的个数
        /// </summary>
        public int Count
        {
            get { return m_pool.Count; }
        }
    }
}
