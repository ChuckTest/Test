using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using AsyncDemoTest;

namespace WaitHandleDemo
{
    public class AsyncMain
    {
        static void Main()
        {
            int threadId = 0;

            AsyncDemo ad = new AsyncDemo();
            AsyncMethodCaller caller = new AsyncMethodCaller(ad.TestMethod);

            IAsyncResult result = caller.BeginInvoke(3000,out threadId,null,null);//开始异步操作

            Thread.Sleep(0);
            Console.WriteLine("Main thread {0} does some work.", Thread.CurrentThread.ManagedThreadId);

            //此处可以执行其他代码

            result.AsyncWaitHandle.WaitOne();//此处会阻塞，直到异步操作完成

            //此处可以执行其他代码

            string returnValue = caller.EndInvoke(out threadId, result);//结束异步操作

            result.AsyncWaitHandle.Close();

            Console.WriteLine("The call executed on thread {0}, with return value \"{1}\".",threadId, returnValue);

            Console.ReadLine();

        }

    }
}
