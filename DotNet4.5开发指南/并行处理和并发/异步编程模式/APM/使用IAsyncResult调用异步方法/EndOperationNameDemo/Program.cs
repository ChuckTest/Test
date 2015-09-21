using System;
using System.Net;

namespace EndOperationNameDemo
{
    /// <summary>
    /// 通过结束异步操作来阻止应用程序执行
    /// </summary>
    class Program
    {
        /// <summary>
        /// 通过直接调用EndOperationName来阻塞主线程
        /// </summary>
        static void Main()
        {
            string str = "www.baidu.com";
            IAsyncResult result = Dns.BeginGetHostEntry(str, null, null);//不使用AsyncCallBack委托，也不传递应用程序的状态
            //这边可以做其他的事情
            Console.WriteLine("在调用EndGetHostEntry方法前还可以处理其他事情");
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
                    Console.WriteLine("IP{0}：{1}", i, h.AddressList[i]);
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
