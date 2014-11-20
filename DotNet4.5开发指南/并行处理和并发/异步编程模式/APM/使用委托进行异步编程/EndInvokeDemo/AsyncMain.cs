using System;
using System.Threading;
using AsyncDemoTest;

namespace EndInvokeDemo
{
    public class AsyncMain
    {
        public static void Main()
        {
            int threadId;

            AsyncDemo ad = new AsyncDemo();//创建一个类的实例

            AsyncMethodCaller caller = new AsyncMethodCaller(ad.TestMethod);//创建一个委托的实例，并将类的方法作为参数传递

            IAsyncResult result = caller.BeginInvoke(3000, out threadId, null, null);//异步调用

            Thread.Sleep(0);//线程被阻塞的毫秒数。 指定零 (0) 以指示应挂起此线程以使其他等待线程能够执行。

            Console.WriteLine("Main thread {0} does some work", Thread.CurrentThread.ManagedThreadId);

            string returnValue = caller.EndInvoke(out threadId,result);//结束异步调用  

            Console.WriteLine("The call executed on thread {0},with return value \"{1}\"", threadId, returnValue);//异步操作的线程托管于线程池的

            Console.ReadLine();
        }
    }
}
