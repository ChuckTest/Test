using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace CommonTest.Log
{
    public class Test
    {
        public static void LogTest()
        {
            try
            {
                OperationLog.Instance.WriteLog("测试日志类", LogType.UI);
                int a = 0;
                //string str = "hello";
                //a = Convert.ToInt32(str);
                Thread thread = new Thread(Add);
                thread.IsBackground = true;
                thread.Start();
                Thread.Sleep(5000);
                thread.Abort();
                thread.Start();
                Console.WriteLine(a);
            }
            catch (Exception ex)
            {
                ExceptionLog.Instance.WriteLog(ex, LogType.DAL);
            }
        }

        static void Add()
        {
            int i = 0;
            while (i < 100)
            {
                Console.WriteLine(i++);
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
