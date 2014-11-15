using System;
using System.Net;

namespace Poll
{
    /// <summary>
    /// 轮询异步操作的状态
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string str = "www.baidu.com";
            IAsyncResult result = Dns.BeginGetHostEntry(str, null, null);//不使用AsyncCallBack委托，也不传递应用程序的状态
            //这边可以做其他的事情
            Console.WriteLine("在调用EndGetHostEntry方法前还可以处理其他事情");
            
            int count = 0;
            //轮询异步操作是否完成的状态
            while (result.IsCompleted == false)//如果异操作没有完成的话
            {
                if ((count + 1) % 10 == 0)
                {
                    Console.WriteLine();
                }
                count++;
                Console.Write(".");
            }
            Console.WriteLine();

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
