using System;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Configuration;

namespace SQLiteFactoryDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Method2();
            Console.Read();
        }


        static void Method()
        {
            string connStr = ConfigurationManager.ConnectionStrings["sqlite"].ConnectionString; ;

            //    ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["SQLite Data Provider"];

            DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SQLite");

            DbConnectionStringBuilder csb = factory.CreateConnectionStringBuilder();
            if (csb != null)
            {
                csb.ConnectionString = connStr;
                if (csb.ContainsKey("MultipleActiveResultSets"))//如果支持MultipleActiveResultSets就设置对应的属性
                {
                    csb["MultipleActiveResultSets"] = true;
                }
                connStr = csb.ConnectionString;
            }

            DbConnection conn = factory.CreateConnection();
            conn.ConnectionString = connStr;
            conn.Open();


            DbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from channeltable";
            cmd.CommandType = CommandType.Text;

            DataTable table;
            DataSet ds = new DataSet();
            SQLiteConnection sqlconn = new SQLiteConnection(conn.ConnectionString);
            using (SQLiteDataAdapter sda = new SQLiteDataAdapter(new SQLiteCommand(cmd.CommandText, sqlconn)))
            {
                sda.Fill(ds);
            }
            table = ds.Tables[0];
            Console.WriteLine(table.Rows.Count);
            conn.Close();
 
        }


        static void Method2()
        {
            string connectionString = @"data source=C:\\Users\\Administrator\\Desktop\\20141111_162853.db3";
            string sql = "select [ChannelID],[ISOpen],[Bridge],[Expression],[Precision],[Sensitivity],[Description],[Unit],ChannelType from [ChannelTable] where [ISOpen]!='0'"; 
            DbUtility db = new DbUtility(connectionString, DbProviderType.SQLite);
            DataTable dt = db.ExecuteDataTable(sql, null);
            Console.WriteLine(dt.Rows.Count);
            DbDataReader reader = db.ExecuteReader(sql, null); 
            reader.Close(); 
        }
    }
}
