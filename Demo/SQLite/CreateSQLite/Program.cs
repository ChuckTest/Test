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
        static string str;
        static string passwd = "zbm";
        static void Main(string[] args)
        {
            CreateSQLiteDB();
            Console.ReadLine();
        }

        static void CreateSQLiteDB()
        {
            try
            {
                string filePath = Environment.CurrentDirectory;
                string fileName = string.Format("{0}.db3", DateTime.Now.ToString("yyyyMMdd_HHmmss"));
                str = filePath + "\\" + fileName;
                SQLiteConnection.CreateFile(str);
                SetPassword();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void SetPassword()
        {
            SQLiteConnectionStringBuilder s = new SQLiteConnectionStringBuilder();
            s.DataSource = str;
            s.Password = passwd;

            //SQLiteConnection conn = new SQLiteConnection(s.ToString());
            //conn.Open();
            //conn.ChangePassword(passwd);
            //conn.Close();

            SQLiteConnection conn = new SQLiteConnection(s.ToString());
            conn.Open();
            conn.ChangePassword(passwd);
            conn.Close();
        }
    }
}
