using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace AsyncProcedure
{
    /// <summary>
    /// 声明一个委托 委托的名字是AsyncHandler
    /// </summary>
    /// <param name="name"></param>
    public delegate void AsyncHandler();//委托的声明方式类似于函数，只是比函数多了一个delegate关键字
    
    static class AsyncTest
    {
        public static void Method()
        {
            Console.WriteLine("AsyncTest类中的Method()函数的线程ID是{0}", Thread.CurrentThread.ManagedThreadId);//Environment.CurrentManagedThreadId
            if (Thread.CurrentThread.IsThreadPoolThread)//判断当前线程是否托管在线程池上
            {
                Console.WriteLine("AsyncTest类中的Method()函数的线程托管于线程池");
            }
            else
            {
                Console.WriteLine("AsyncTest类中的Method()函数的线程没有托管在线程池上");
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

            //把Method 方法分配给委托对象
            AsyncHandler async = AsyncTest.Method; //

            //发起一个异步调用的方法,返回IAsyncResult 对象
            IAsyncResult result = async.BeginInvoke(null,null);

            //这里会阻碍线程,直到方法执行完毕
            async.EndInvoke(result);

            Console.Read();
        }
    }
}
