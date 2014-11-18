using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;

namespace CreateSQLite
{
    class Program
    {
        static string file = string.Empty;
        static string password = string.Empty;

        static void Main(string[] args)
        {
            CreateSQLiteDB();
            Console.ReadLine();
        }

        static void CreateSQLiteDB()
        {
            try
            {
                string str1 = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string str2 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                file = str2 + "\\" + str1 + ".db3";
                SQLiteConnection.CreateFile(file);//单独创建文件或设置某一个文件的密码是可以的，但是两者结合就无法使用

                //SetSQLitePassWord();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 获取数据库连接字符串
        /// </summary>
        /// <returns></returns>
        public static string GetConnectString()
        {
            SQLiteConnectionStringBuilder s = new SQLiteConnectionStringBuilder();
            s.DataSource = file;
            s.Password = password;
            return s.ToString();
        }

        /// <summary>
        /// 给数据库设置密码
        /// </summary>
        private static void SetSQLitePassWord()
        {
            try
            {
                SQLiteConnection conn = new SQLiteConnection(GetConnectString());
                conn.Open();
                conn.ChangePassword(password);
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
