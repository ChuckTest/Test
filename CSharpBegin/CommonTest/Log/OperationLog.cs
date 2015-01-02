using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace CommonTest.Log
{
    public class OperationLog : Log
    {
        private OperationLog()
        { }

        private static OperationLog m_instance = new OperationLog();

        public static OperationLog Instance
        {
            get { return m_instance; }
        }

        protected string CreateDirectory(DateTime dt)
        {
            string strPath = m_filepath + "\\OperateLog";
            try
            {
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

        public override void WriteLog(object obj, LogType logType)
        {
            if (EnableLog)
            {
                if (obj is string)
                {
                    DateTime dt = DateTime.Now;
                    string fileName = CreateDirectory(dt);
                    fileName = fileName + "\\" + dt.ToString("yyyyMMdd") + ".txt";//将来需要考虑文件的大小
                    WriteLog(obj.ToString(), fileName);
                }
            }
        }

        public override void SetLogPath(string filePath)
        {
            m_filepath = filePath;
        }
    }
}
