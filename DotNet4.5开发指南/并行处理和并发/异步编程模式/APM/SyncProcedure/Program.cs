using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace SyncProcedure
{
    //同步程序的试验
    class Program
    {
        //平常写的Hello 程序是同一个线程的,而且不是线程池理的线程程序.
        static void Main(string[] args)
        {
            // 查看当前的线程ID, 是否线程池里面的线程
            Console.WriteLine("1,Thread ID:#{0},Is PoolThread?{1}",
Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsThreadPoolThread);

            SyncTest test = new SyncTest();
            string val = test.Hello("Andy Huang");
            Console.WriteLine(val);

            Console.ReadLine();

            //1,Thread ID:#9,Is PoolThread?False
            //2,Thread ID:#9,Is PoolThread?False
            //Hello:Andy Huang
        }
    }
}
