using System;
using System.Threading;

namespace SemaphoreDemo
{
    /// <summary>
    /// http://www.cnblogs.com/hsrzyn/articles/1588792.html
    /// </summary>
    class MyThread
    {
        internal Thread thread;
        static Semaphore semaphore = new Semaphore(2, 2);

        internal MyThread(string name)
        {
            thread = new Thread(Run);
            thread.Name = name;
            thread.Start();
        }

        void Run()
        {
            Console.WriteLine(string.Format("{0}正在等待一个许可证", thread.Name));

            //申请一个许可证
            semaphore.WaitOne();

            Console.WriteLine(string.Format("{0}申请到许可证", thread.Name));

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(string.Format("{0}: {1}  {2}", thread.Name, i,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")));
                Thread.Sleep(1000);
            }

            Console.WriteLine(string.Format("{0}释放许可证", thread.Name));
            semaphore.Release(1);
        }
    }
}
