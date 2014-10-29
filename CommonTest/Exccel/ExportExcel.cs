using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using CommonTest.Log;
namespace CommonTest.Exccel
{
    public class ExportExcel
    {
        public static void ExcelTest()
        {
            ExportDataSet();
        }

        public static void ExportDataSet()
        {
            Console.WriteLine("开始导出数据集  {0}", DateTime.Now.ToString("yyyyMMdd_HHmmss.fff"));
            try
            {
                DataTable table;
                DataSet dataSet = CreateDataSet();
                for (int i = 0; i < dataSet.Tables.Count; i++)
                {
                    table = dataSet.Tables[i];
                    for (int j = 0; j < 1000; j++)
                    {
                        table.Rows.Add();
                        table.Rows[j]["ID"] = j;
                        table.Rows[j]["Time"] = DateTime.Now.AddSeconds(1).ToString("yyyyMMdd_HHmmss.fff");
                    }
                }
                if (Directory.Exists(string.Format("{0}\\Excel", Environment.CurrentDirectory)) == false)
                {
                    Directory.CreateDirectory(string.Format("{0}\\Excel", Environment.CurrentDirectory));
                }
                string strFile = string.Format("{0}\\Excel\\{1}.xlsx", Environment.CurrentDirectory, DateTime.Now.ToString("yyyyMMdd_HHmmss"));
                ExcelOperation.ExportExcel(dataSet, strFile);
                Console.WriteLine("数据集导出完成 {0}", DateTime.Now.ToString("yyyyMMdd_HHmmss.fff"));
            }
            catch (Exception ex)
            {
                ExceptionLog.Instance.WriteLog(ex, LogType.UI);
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }


        public static void ExportDataTable()
        {
            try
            {
                Console.WriteLine("开始导出数据表  {0}", DateTime.Now.ToString("yyyyMMdd_HHmmss.fff"));

                DataTable table = CreateDataTable("采集单元5536");

                for (int i = 0; i < 1000; i++)
                {
                    table.Rows.Add();
                    table.Rows[i]["ID"] = i;
                    table.Rows[i]["Time"] = DateTime.Now.AddSeconds(1).ToString("yyyyMMdd_HHmmss.fff");
                }
                if (Directory.Exists(string.Format("{0}\\Excel", Environment.CurrentDirectory)) == false)
                {
                    Directory.CreateDirectory(string.Format("{0}\\Excel", Environment.CurrentDirectory));
                }
                string strFile = string.Format("{0}\\Excel\\{1}.xlsx", Environment.CurrentDirectory, DateTime.Now.ToString("yyyyMMdd_HHmmss"));
                ExcelOperation.ExportExcel(table, strFile);
                Console.WriteLine("数据表导出完毕  {0}", DateTime.Now.ToString("yyyyMMdd_HHmmss.fff"));
            }
            catch (Exception ex)
            {
                ExceptionLog.Instance.WriteLog(ex, LogType.UI);
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        public static DataSet CreateDataSet()
        {
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(CreateDataTable("数据表1"));
            dataSet.Tables.Add(CreateDataTable("数据表2"));
            return dataSet;
        }

        public static DataTable CreateDataTable(string tableName)
        {
            DataTable table = new DataTable();
            table.TableName = tableName;
            DataColumn column;

            column = new DataColumn();
            column.ColumnName = "ID";
            column.DataType = Type.GetType("System.Int32");
            table.Columns.Add(column);

            column = new DataColumn();
            column.ColumnName = "Time";
            column.DataType = Type.GetType("System.String");
            table.Columns.Add(column);

            return table;
        }
    }
}
