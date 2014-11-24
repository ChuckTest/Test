using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;
using AsyncDemoTest;

namespace AsyncCallbackDemo
{
    /// <summary>
    /// 异步调用完成时执行回调方法
    /// http://msdn.microsoft.com/zh-cn/library/2e08f6yc(v=vs.110).aspx
    /// http://msdn.microsoft.com/en-us/library/2e08f6yc(v=vs.110).aspx
    /// </summary>
    class AsyncMain
    {
        static void Main(string[] args)
        {
            AsyncDemo.JudgeThread(System.Reflection.MethodBase.GetCurrentMethod().Name, Thread.CurrentThread);

            AsyncDemo ad = new AsyncDemo();

            //public delegate string AsyncMethodCaller(int callDuration,out int threadId);
            AsyncMethodCaller caller = new AsyncMethodCaller(ad.TestMethod);

            int threadId;

            //public delegate void AsyncCallback(IAsyncResult ar);
            caller.BeginInvoke(3000, out threadId, AsycnCallback, "回调方法执行在线程ID为{0}的线程上,返回值是{1}");//开始异步执行ad.TestMethod,完成之后，调用AsycnCallback方法

            Console.WriteLine("主线程结束");

            Console.ReadLine();
        }

        /// <summary>
        /// 回调方法
        /// </summary>
        /// <param name="result"></param>
        static void AsycnCallback(IAsyncResult result)
        {
            AsyncDemo.JudgeThread(System.Reflection.MethodBase.GetCurrentMethod().Name, Thread.CurrentThread);

            AsyncResult ar = (AsyncResult)result;//BeginInvoke返回的IAsyncResult对象可以强制转换为AsyncResult

            AsyncMethodCaller caller = (AsyncMethodCaller)ar.AsyncDelegate;//获取调用BeginInvoke的委托对象   还需要强制转换成自己定义的委托类型

            string formatString = (string)ar.AsyncState;

            int threadId;

            string returnValue = caller.EndInvoke(out threadId, ar);//调用EndInvoke的时候，需要得到委托对象

            Console.WriteLine(formatString, threadId, returnValue);
        }
    }
}
