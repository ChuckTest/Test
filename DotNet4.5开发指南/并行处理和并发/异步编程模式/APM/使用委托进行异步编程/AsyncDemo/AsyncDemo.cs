using System;
using System.Threading;

namespace AsyncDemoTest
{
    /// <summary>
    /// 定义一个委托类型
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
            JudgeThread(System.Reflection.MethodBase.GetCurrentMethod().Name, Thread.CurrentThread);
            Console.WriteLine("TestMethod begins.");
            Thread.Sleep(callDuration);
            threadId = Thread.CurrentThread.ManagedThreadId;
            return string.Format("My call time is {0}", callDuration);
        }

        /// <summary>
        /// 判断某一个线程是否托管于线程池，是否是后台线程
        /// </summary>
        /// <param name="name"></param>
        /// <param name="thread"></param>
        public static void JudgeThread(string name, Thread thread)
        {
            if (thread.IsThreadPoolThread)
            {
                Console.WriteLine("{0}所处的线程ID为{1}，是线程池上的线程", name, thread.ManagedThreadId);
            }
            else
            {
                Console.WriteLine("{0}所处的线程ID为{1}，不是线程池上的线程", name, thread.ManagedThreadId);
            }
            if (thread.IsBackground)
            {
                Console.WriteLine("{0}所处的线程ID为{1}，是后台线程", name, thread.ManagedThreadId);
            }
            else 
            {
                Console.WriteLine("{0}所处的线程ID为{1}，不是后台线程", name, thread.ManagedThreadId);
            }
        }
    }
}
