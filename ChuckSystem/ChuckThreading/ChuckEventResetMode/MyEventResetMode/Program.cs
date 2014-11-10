using System;
using System.Threading;

namespace MyEventResetMode
{
    class Program
    {
        /// <summary>
        /// EventWaitHandle变量  可以赋值AutoReset和ManualReset
        /// </summary>
        private static EventWaitHandle ewh;

        /// <summary>
        /// 线程的计数器 在进入线程后加1  释放线程后减1
        /// </summary>
        private static long threadCount = 0;

        /// <summary>
        /// 让主线程阻塞的 EventWaitHandle 到所有开辟出来的线程全部被释放
        /// </summary>
        private static EventWaitHandle clearCount = new EventWaitHandle(false, EventResetMode.AutoReset);

        static void Main(string[] args)
        {
            //创建一个AutoReset类型的EventWaitHandle
            ewh = new EventWaitHandle(false, EventResetMode.AutoReset);

            //创建5个线程,将i作为参数传递，以识别不同的线程
            for (int i = 0; i <= 4; i++)
            {
                Thread t = new Thread(
                    new ParameterizedThreadStart(ThreadProc)
                );
                t.Start(i);
                Thread.Sleep(100);//确保线程是有先后顺序的  方便后面判断AutoReset是否随机释放单个线程
            }

            while (Interlocked.Read(ref threadCount) < 5)//等待所有的线程启动并阻塞
            {
                Thread.Sleep(500);
            }

            Console.WriteLine();

            while (Interlocked.Read(ref threadCount) > 0)//逐个释放ewh阻塞的线程
            {
                Console.WriteLine("Press ENTER to release a waiting thread.");
                Console.ReadLine();

                WaitHandle.SignalAndWait(ewh, clearCount);//向一个 WaitHandle 发出信号并等待另一个。  相当于下面两个语句
                /*
                ewh.Set();//收到信号之后，随机释放一个被它阻塞的线程,其它的保持阻塞
                clearCount.WaitOne();//阻塞
                */
                //ewh是要发出信号的WaitHandle,  ewh收到信号之后，释放单个线程，然后再自动阻塞
                //clearCount是要等待的WaitHandle    clearCount在此等待  相当于调用了clearCount.WaitOne();

            }
            Console.WriteLine();

            //创建一个ManualReset类型的EventWaitHandle
            ewh = new EventWaitHandle(false, EventResetMode.ManualReset);

            //创建5个线程,将i作为参数传递，以识别不同的线程
            for (int i = 0; i <= 4; i++)
            {
                Thread t = new Thread(
                    new ParameterizedThreadStart(ThreadProc)
                );
                t.Start(i);
            }


            while (Interlocked.Read(ref threadCount) < 5)//等待所有线程启动并阻塞
            {
                Thread.Sleep(500);
            }

            Console.WriteLine("Press ENTER to release the waiting threads.");
            Console.ReadLine();
            ewh.Set();   //一次释放所有被它阻塞的线程

            Console.Read();
        }

        public static void ThreadProc(object data)
        {
            int index = (int)data;

            Interlocked.Increment(ref threadCount);//计数增加
            Console.WriteLine("Thread {0} blocks.", data);
            ewh.WaitOne();//等待ewh发出信号    

            Console.WriteLine("Thread {0} exits.", data);
            Interlocked.Decrement(ref threadCount);//计数减少

            clearCount.Set();//释放主线程一次
        }
    }
}
