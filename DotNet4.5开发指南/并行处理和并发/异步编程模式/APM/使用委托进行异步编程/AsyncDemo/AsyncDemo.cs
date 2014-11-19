using System;
using System.Threading;

namespace AsyncDemoTest
{
    /// <summary>
    /// 定义一个委托
    /// </summary>
    /// <param name="callDuration"></param>
    /// <param name="threadId"></param>
    /// <returns></returns>
    public delegate string AsyncMethodCaller(int callDuration,out int threadId);

    /// <summary>
    /// 定义一个类
    /// </summary>
    public class AsyncDemo
    {
        public string TestMethod(int callDuration, out int threadId)
        {
            Console.WriteLine("TestMethod begins.");
            Thread.Sleep(callDuration);
            threadId = Thread.CurrentThread.ManagedThreadId;
            return string.Format("My call time is {0}", callDuration);
        }
    }
}
