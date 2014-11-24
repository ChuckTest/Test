using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using AsyncDemoTest;

namespace PollingDemo
{
    /// <summary>
    /// 通过轮询IAsyncResult的IsCompleted属性，来判断异步操作是否完成
    /// http://msdn.microsoft.com/zh-cn/library/2e08f6yc(v=vs.110).aspx
    /// </summary>
    class AsyncMain
    {
        static void Main(string[] args)
        {
            AsyncDemo.JudgeThread(System.Reflection.MethodBase.GetCurrentMethod().Name, Thread.CurrentThread);
            int threadId;

            AsyncDemo ad = new AsyncDemo();
            AsyncMethodCaller caller = new AsyncMethodCaller(ad.TestMethod);
            IAsyncResult result = caller.BeginInvoke(3000, out threadId, null, null);
            int i = 0;
            while (result.IsCompleted == false)//轮询异步操作是否完成，没有完成的话,就一直循环，轮询间隔为500ms
            {
                Console.WriteLine("第{0}次轮询异步操作状态", ++i);
                Thread.Sleep(500);
            }
            string returnValue = caller.EndInvoke(out threadId, result);

            Console.WriteLine("异步操作在线程ID为{0}的线程上执行,返回值是{1}", threadId, returnValue);

            Console.ReadLine();
        }
    }
}
