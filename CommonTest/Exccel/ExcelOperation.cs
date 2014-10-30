using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataTable = System.Data.DataTable;//和Microsoft.Office.Interop.Excel.DataTable有歧义
using System.Reflection;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using CommonTest.Log;
namespace CommonTest.Exccel
{
    public class ExcelOperation
    {

        private ExcelOperation()
        { }

        /// <summary>
        /// 导出数据表
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        public static bool ExportExcel(DataTable dt, string filePath)
        {
            try
            {
#if Debug
                Console.WriteLine(Environment.NewLine + "单表导出开始new  " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
#endif
                ExcelHelper Excel = new ExcelHelper(filePath);
                Excel.CreateWorkSheet();
                Excel.DataTableToExcel(dt);
                Excel.DeleteWorkSheet("Sheet");
                Excel.SaveAsFile();
#if Debug
                Console.WriteLine("单表导出结束new  {0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
#endif
                return true;
            }
            catch (Exception ex)
            {
                ExceptionLog.Instance.WriteLog(ex, LogType.UI);
                throw;
            }
        }

        /// <summary>
        /// 导出数据表
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <param name="filePath">文件路径</param>
        /// <param name="rowsCountEveryWorkSheet">worksheet允许的行数</param>
        /// <returns></returns>
        public static bool ExportExcel(DataTable dt, string filePath, int rowsCountEveryWorkSheet)
        {
            try
            {
#if Debug
                Console.WriteLine(Environment.NewLine + "单表导出开始new  " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
#endif
                ExcelHelper Excel = new ExcelHelper(filePath);
                Excel.RowsCountEveryWorkSheet = rowsCountEveryWorkSheet;
                Excel.CreateWorkSheet();
                Excel.DataTableToExcel(dt);
                Excel.DeleteWorkSheet("Sheet");
                Excel.SaveAsFile();
#if Debug
                Console.WriteLine("单表导出结束new  {0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
#endif
                return true;
            }
            catch (Exception ex)
            {
                ExceptionLog.Instance.WriteLog(ex, LogType.UI);
                throw;
            }
        }

        /// <summary>
        /// 导出数据集
        /// </summary>
        /// <param name="ds">数据集</param>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        public static bool ExportExcel(DataSet ds, string filePath)
        {
            try
            {
#if Debug
                Console.WriteLine(Environment.NewLine + "多表导出开始new  " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
#endif
                if (ds == null || ds.Tables.Count == 0) return false;
                ExcelHelper Excel = new ExcelHelper(filePath);
                foreach (DataTable dt in ds.Tables)
                {
                    Excel.CreateWorkSheet();
                    Excel.DataTableToExcel(dt);
                }
                Excel.DeleteWorkSheet("Sheet");
                Excel.SaveAsFile();
#if Debug
                Console.WriteLine("多表导出结束new  {0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
#endif
                return true;
            }
            catch (Exception ex)
            {
                ExceptionLog.Instance.WriteLog(ex, LogType.UI);
                throw;
            }
        }

        /// <summary>
        /// 导出数据集
        /// </summary>
        /// <param name="ds">数据集</param>
        /// <param name="filePath">文件路径</param>
        /// <param name="rowsCountEveryWorkSheet">worksheet允许的行数</param>
        /// <returns></returns>
        public static bool ExportExcel(DataSet ds, string filePath, int rowsCountEveryWorkSheet)
        {
            try
            {
#if Debug
                Console.WriteLine(Environment.NewLine + "多表导出开始new  " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
#endif
                if (ds == null || ds.Tables.Count == 0) return false;
                ExcelHelper Excel = new ExcelHelper(filePath);
                Excel.RowsCountEveryWorkSheet = rowsCountEveryWorkSheet;
                foreach (DataTable dt in ds.Tables)
                {
                    Excel.CreateWorkSheet();
                    Excel.DataTableToExcel(dt);
                }
                Excel.DeleteWorkSheet("Sheet");
                Excel.SaveAsFile();
#if Debug
                Console.WriteLine("多表导出结束new  {0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
#endif
                return true;
            }
            catch (Exception ex)
            {
                ExceptionLog.Instance.WriteLog(ex, LogType.UI);
                throw;
            }
        }
    }
}
