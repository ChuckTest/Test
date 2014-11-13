using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace AsyncProcedure
{
    public delegate string AsyncEventHandler(string name);
    
    class AsyncTest
    {
        public string Hello(string name)
        {
            // 查看当前的线程ID, 是否线程池里面的线程
            Console.WriteLine("2,Thread ID:#{0},Is PoolThread?{1}",Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsThreadPoolThread);
            return "Hello:" + name;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {  
            // 查看当前的线程ID, 是否线程池里面的线程
            Console.WriteLine("1,Thread ID:#{0},Is PoolThread?{1}", Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsThreadPoolThread);
           
            AsyncTest test = new AsyncTest();

            //把Hello 方法分配给委托对象
            AsyncEventHandler async = test.Hello; //

            //发起一个异步调用的方法,赋值"Andy Huang", 返回IAsyncResult 对象
            IAsyncResult result = async.BeginInvoke("Andy Huang", null, null);

            //这里会阻碍线程,直到方法执行完毕
            string val = async.EndInvoke(result);

            Console.WriteLine(val);
            Console.ReadLine(); // 让黑屏等待,不会直接关闭..
        }
    }
}
