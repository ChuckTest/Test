using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
namespace CommonTest.Log
{
    public abstract class Log
    {
        /// <summary>
        /// 默认的保存文件路径为当前路径
        /// </summary>
        protected string m_filepath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+@"\Log";

        private bool m_enablelog = true;

        private int m_filesize = 1024 * 1024;

        /// <summary>
        /// 是否启用日志
        /// </summary>
        public bool EnableLog
        {
            get { return m_enablelog; }
            set { m_enablelog = value; }
        }

        /// <summary>
        /// 日志文件大小
        /// </summary>
        public int FileSize
        {
            get { return m_filesize; }
            set { m_filesize = value; }
        }

        /// <summary>
        /// 写日志
        /// </summary>
        public virtual void WriteLog(object obj,LogType logType) { }

        /// <summary>
        /// 设置日志路径
        /// </summary>
        /// <param name="filePath"></param>
        public virtual void SetLogPath(string filePath) { }

        /// <summary>
        /// 将字符串形式的异常打印到文件
        /// </summary>
        /// <param name="msg">字符串</param>
        /// <param name="fileName">包含文件名的文件路径</param>
        protected void WriteLog(string msg,string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return;
            }

            try
            {
                using (StreamWriter streamWriter = File.AppendText(fileName))
                {
                    streamWriter.Write(string.Format("[{0}]{2}{1}{2}", DateTime.Now, msg, Environment.NewLine));
                    streamWriter.Flush();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
