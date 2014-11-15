using System;
using System.Net;

namespace AsyncWaitHandle
{
    /// <summary>
    /// 使用 AsyncWaitHandle 阻止应用程序的执行
    /// </summary>
    class Program
    {
        /// <summary>
        /// 通过调用IAsyncResult中AsyncWaitHandle的WaitOne方法来阻塞主线程
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string str = "www.baidu.com";
            IAsyncResult result = Dns.BeginGetHostEntry(str, null, null);//不使用AsyncCallBack委托，也不传递应用程序的状态
            //这边可以做其他的事情
            Console.WriteLine("在调用EndGetHostEntry方法前还可以处理其他事情");
            result.AsyncWaitHandle.WaitOne();//不加等待的时间，就一直阻塞,直到BeginGetHostEntry完成
            try
            {
                //获取IP主机入口
                IPHostEntry h = Dns.EndGetHostEntry(result);//如果BeginGetHostEntry没有完成的话，这边会阻塞
                for (int i = 0; i < h.Aliases.Length; i++)
                {
                    Console.WriteLine("别名{0}：{1}", i, h.Aliases[i]);
                }
                for (int i = 0; i < h.AddressList.Length; i++)
                {
                    Console.WriteLine("IP{0}：{1}", i, h.AddressList[i].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
