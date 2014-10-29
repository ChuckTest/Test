using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace CommonTest.Log
{
    public class ExceptionLog : Log
    {
        private ExceptionLog()
        { }

        private static ExceptionLog m_instance = new ExceptionLog();

        public static ExceptionLog Instance
        {
            get { return m_instance; }
        }

        public override void WriteLog(object obj, LogType logType)
        {
            if (EnableLog)
            {
                if (obj is Exception)
                {
                    DateTime dt = DateTime.Now;
                    string fileName = CreateDirectory(dt, logType);
                    fileName = fileName + "\\" + dt.ToString("yyyyMMdd") + ".txt";//将来需要考虑文件的大小
                    WriteExceptionLog((Exception)obj, fileName);
                }
            }
        }

        private string CreateDirectory(DateTime dt,LogType logType)
        {
            string strPath = m_filepath + "\\ExceptionLog";
            try
            {
                if (Directory.Exists(strPath) == false)
                {
                    Directory.CreateDirectory(strPath);
                }
                strPath = strPath + "\\" + logType.ToString();
                if (Directory.Exists(strPath) == false)
                {
                    Directory.CreateDirectory(strPath);
                }
                return strPath;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void SetLogPath(string filePath)
        {
            m_filepath = filePath;
        }

        /// <summary>
        /// 将异常处理成字符串的形式,然后写入文件
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="fileName"></param>
        private void WriteExceptionLog(Exception ex, string fileName)
        {
            StringBuilder innerExceptionString = new StringBuilder();

            if (ex.InnerException != null)//内部异常存在
            {
                innerExceptionString.Append(string.Format("错误信息:{0}\r\n异常类型:{1}\r\n程序集:{2}\r\n方法:{3}\r\n跟踪栈信息:\r\n{4}",
                    ex.InnerException.Message,//错误信息
                    ex.InnerException.GetType(),//异常类型
                    ex.InnerException.Source,//程序集
                    ex.InnerException.TargetSite,//方法
                    ex.InnerException.StackTrace));//跟踪堆栈信息
            }

            if (!string.IsNullOrEmpty(innerExceptionString.ToString()))//如果 innerExceptionString.ToString() 参数为 null 或空字符串 ("")，则为 true；否则为 false。
            {
                WriteLog(string.Format("错误信息:{0}{1}异常类型:{2}{1}内部异常{1}({1}{3}{1}){1}程序集:{4}{1}方法:{5}{1}跟踪栈信息:{1}{6}{1}",
                ex.Message,
                Environment.NewLine,
                ex.GetType(),
                innerExceptionString,
                ex.Source,
                ex.TargetSite,
                ex.StackTrace), fileName);//写入文件
            }
            else
            {
                WriteLog(string.Format("错误信息:{0}{1}异常类型:{2}{1}程序集:{3}{1}方法:{4}{1}跟踪栈信息:{1}{5}{1}",
                    ex.Message,
                    Environment.NewLine,
                    ex.GetType(),
                    ex.Source,
                    ex.TargetSite,
                    ex.StackTrace), fileName);//写入文件
            }
        }
    }
}
