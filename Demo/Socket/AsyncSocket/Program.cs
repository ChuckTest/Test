using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
namespace AsyncSocket
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IPEndPoint ipEndPoint = null;
                int port = 1333;
                string hostName = Dns.GetHostName();
                IPAddress[] ipArray = Dns.GetHostAddresses(hostName);
                if (ipArray.Length > 0)
                {
                    if (ipArray.Length == 2)//获取的是ipv6和ipv4的地址
                    {
                        ipEndPoint = new IPEndPoint(ipArray[1], port);
                    }
                    else if (ipArray.Length == 1)//获取的是ipv4的地址
                    {
                        ipEndPoint = new IPEndPoint(ipArray[0], port);
                    }
                    else
                    {
                        throw new Exception("获取本机的IP失败");
                    }

                    Server objServer = new Server(1000, 10);
                    objServer.Init();
                    if (ipEndPoint != null)
                    {
                        objServer.Start(ipEndPoint);
                    }
                }
                else 
                {
                    throw new Exception("获取本机的IP失败");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("遇到异常{0}", ex.Message);
            }

            Console.ReadKey();
        }
    }
}
