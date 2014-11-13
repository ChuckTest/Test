using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace SyncProcedure
{
    class SyncTest
    {
        public string Hello(string name)
        {        
            // 查看当前的线程ID, 是否线程池里面的线程
            Console.WriteLine("2,Thread ID:#{0},Is PoolThread?{1}",
  Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsThreadPoolThread);
            return "Hello:" + name;
        }
    }
}
