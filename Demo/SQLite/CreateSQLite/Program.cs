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
        static void Main(string[] args)
        {
            try
            {
                string filePath = Environment.CurrentDirectory;
                string fileName = string.Format("{0}.db3",DateTime.Now.ToString("yyyyMMdd_HHmmss"));
                string str = filePath + "\\" + fileName;
                SQLiteConnection.CreateFile(str);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
