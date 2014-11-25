using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Messaging;

namespace AsyncDelegateDemo
{
    class DemonstrateAsyncPattern
    {
        ManualResetEvent waiter;

        int targetNumber = 1000589023;

        public void FactorizeNumberAndWait()
        {
            AsyncFactorCaller factorDelegate = new AsyncFactorCaller(PrimeFactorFinder.Factorize);
            int number = targetNumber;
            int temp = 0;

            IAsyncResult result = factorDelegate.BeginInvoke(number, ref temp, ref temp, null, null);

            while (result.IsCompleted == false)//轮询异步操作状态
            {
                result.AsyncWaitHandle.WaitOne(1000);//等待1秒
            }
            result.AsyncWaitHandle.Close();

            int factor1 = 0;
            int factor2 = 0;

            bool flag = factorDelegate.EndInvoke(ref factor1, ref factor2, result);//结束异步操作，并获取返回值

            Console.WriteLine("Sequential:Factors of {0}: {1} {2} -{3}", number, factor1, factor2, flag);
        }

        /// <summary>
        /// 使用回调方法的BeginInvoke
        /// </summary>
        public void FactorizeNumberUsingCallback()
        {
            //public delegate bool AsyncFactorCaller(int number,ref int primeFactor1,ref int primeFactor2);
            AsyncFactorCaller factorDelegate = new AsyncFactorCaller(PrimeFactorFinder.Factorize);
            int number = targetNumber;
            int temp = 0;

            waiter = new ManualResetEvent(false);

            factorDelegate.BeginInvoke(number,ref temp,ref temp,FactorizeResults,number);//开始异步操作

            waiter.WaitOne();//阻塞，等待waiter.Set();信号
        }

        /// <summary>
        /// 回调方法
        /// </summary>
        /// <param name="result"></param>
        public void FactorizeResults(IAsyncResult result)
        {
            int factor1 = 0;
            int factor2 = 0;
            AsyncResult ar = (AsyncResult)result;//强制转换
            object o = ar.AsyncDelegate;//获取委托对象
            AsyncFactorCaller caller = (AsyncFactorCaller)o;//将委托对象转换为具体的类型

            int number = (int)result.AsyncState;

            bool flag = caller.EndInvoke(ref factor1,ref factor2,result);//结束异步，并获取返回值

            Console.WriteLine("On Callback:Factors of {0}: {1} {2} -{3}", number, factor1, factor2, flag);

            waiter.Set();
        }
    }
}
