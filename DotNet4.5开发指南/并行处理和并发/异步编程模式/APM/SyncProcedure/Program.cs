using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace SyncProcedure
{
    static class SyncTest
    {
        public static void Method()
        {

            Console.WriteLine("SyncTest类中的Method()函数的线程ID是{0}", Thread.CurrentThread.ManagedThreadId);//Environment.CurrentManagedThreadId
            if (Thread.CurrentThread.IsThreadPoolThread)//判断当前线程是否托管在线程池上
            {
                Console.WriteLine("SyncTest类中的Method()函数的线程托管于线程池");
            }
            else
            {
                Console.WriteLine("SyncTest类中的Method()函数的线程没有托管在线程池上");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program类中的Main()函数的线程ID是{0}", Thread.CurrentThread.ManagedThreadId);//Environment.CurrentManagedThreadId
            if (Thread.CurrentThread.IsThreadPoolThread)//判断当前线程是否托管在线程池上
            {
                Console.WriteLine("Program类中的Main()函数的线程托管于线程池");
            }
            else
            {
                Console.WriteLine("Program类中的Main()函数的线程没有托管在线程池上");
            }
            Console.WriteLine();

            SyncTest.Method();//调用静态类的静态方法

            Console.Read();//阻塞，确保能看到上面的打印信息
        }
    }
}
