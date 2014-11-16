using System;
using System.Net;
using System.Threading;
using System.Collections.Specialized;
using System.Collections;

namespace AsyncCallBackDemo
{
    class Program
    {
        /// <summary>
        /// 计数未解析的域名或IP的数量
        /// </summary>
        static int count;

        /// <summary>
        /// 保存[域名或IP]解析的结果或者异常信息
        /// </summary>
        static ArrayList hostData = new ArrayList();

        /// <summary>
        /// 存放域名或IP
        /// </summary>
        static StringCollection hostNames = new StringCollection();

        static void Main(string[] args)
        {
            string host = string.Empty;
            //循环输入域名或IP
            do
            {
                Console.WriteLine("请输入域名或IP(或Enter结束)");
                host = Console.ReadLine();
                if (host.Length > 0)
                {
                    Interlocked.Increment(ref count);//未解析数量加1
                    Dns.BeginGetHostEntry(host, GetDnsInfo, host);
                }
            } while (host.Length > 0);
            
            while (count > 0)
            {
                Console.WriteLine("剩余{0}个解析请求。", count);
                Thread.Sleep(5000);//遇到不能正常解析的域名的时候，Dns.BeginGetHostEntry会执行很长时间,之后才会执行GetDnsInfo这个callback
            }
            Console.WriteLine();

            for (int i = 0; i < hostNames.Count; i++)
            {
                Console.WriteLine(hostNames[i] + "的解析：");
                IPHostEntry ip = hostData[i] as IPHostEntry;
                if (ip == null)//说明hostData[i]中保存的不是IPHostEntry而是异常信息
                {
                    Console.WriteLine(hostData[i]);
                }
                else
                {
                    for (int j = 0; j < ip.AddressList.Length; j++)
                    {
                        Console.WriteLine(ip.AddressList[j]);
                    }
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        /// <summary>
        /// 回调方法
        /// </summary>
        /// <param name="result"></param>
        static void GetDnsInfo(IAsyncResult result)
        {
            string host = (string)result.AsyncState;
            hostNames.Add(host);
            try 
            {
                IPHostEntry ip = Dns.EndGetHostEntry(result);//获取Begin的结果
                hostData.Add(ip);//将解析的结果加入hostData
            }
            catch(Exception ex)
            {
                hostData.Add(ex.Message);//将异常信息加入hostData
            }
            finally
            {
                Interlocked.Decrement(ref count);//解析完成,未解析数量减1
            }
        }
    }
}
