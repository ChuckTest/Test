using System;
using System.Threading;

namespace SemaphoreDemo
{
    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        static Semaphore _pool;
        static int _padding;
        static void Main(string[] args)
        {
            Method3();
            Console.ReadKey();
        }

        static void Method3()
        {
            try
            {
                _pool = new Semaphore(0, 3);
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine(string.Format("准备第{0}次释放", i + 1));
                    Console.WriteLine(string.Format("返回的计数是{0}" ,_pool.Release()));
                    Console.WriteLine(string.Format("第{0}次释放成功", i + 1));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// http://msdn.microsoft.com/en-us/library/cckchaw6(v=vs.110).aspx
        /// </summary>
        static void Method2()
        {
            MyThread thread1 = new MyThread("Thread #1");
            MyThread thread2 = new MyThread("Thread #2");
            MyThread thread3 = new MyThread("Thread #3");
            MyThread thread4 = new MyThread("Thread #4");

            thread1.thread.Join();
            thread2.thread.Join();
            thread3.thread.Join();
            thread4.thread.Join();
        }

        /// <summary>
        /// http://msdn.microsoft.com/en-us/library/cckchaw6(v=vs.110).aspx
        /// </summary>
        static void Method1()
        {
            try
            {
                _pool = new Semaphore(0, 3);
                for (int i = 1; i <= 5; i++)
                {
                    Thread thread = new Thread(new ParameterizedThreadStart(Worker));
                    thread.Start(i);
                }

                Thread.Sleep(500);

                Console.WriteLine("主线程调用信号量的Release(3)");

                int num = _pool.Release(2);

                Console.WriteLine(string.Format("主线程_pool.Release(3)的返回值是{0}", num));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Worker(object num)
        {
            Console.WriteLine(string.Format("线程{0}启动，并等待信号", num));
            _pool.WaitOne();

            int padding = Interlocked.Add(ref _padding, 100);
            Console.WriteLine(string.Format("线程{0}进入信号量", num));

            Thread.Sleep(1000 + padding);

            //_pool.Release()等价与_pool.Release(1)
            Console.WriteLine(string.Format("线程{0}退出信号量,线程{0}的前一个信号量计数是{1}", num, _pool.Release()));
        }
    }
}
