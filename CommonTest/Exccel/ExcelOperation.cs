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
namespace CommonTest.Exccel
{
    public class ExcelOperation
    {
        private static object missing = Missing.Value;//或者missing = System.Type.Missing;两者等价

        private static Application app;

        /// <summary>
        /// 工作簿
        /// </summary>
        private static Workbook workBook;

        /// <summary>
        /// 工作表
        /// </summary>
        private static Worksheet workSheet;

        /// <summary>
        /// 导入数据表时，当前数据表所需要的worksheet的数量
        /// </summary>
        private static int sheetCount = 1;

        /// <summary>
        /// 导入数据集时，假如正在导入第3个数据表，那么totalSheetCount是这3张表所需要的worksheet的数量
        /// </summary>
        private static int totalSheetCount = 0;

        /// <summary>
        /// 导入数据集时，假如正在导入第3个数据表，那么totalSheetCount是前2张表所需要的worksheet的数量
        /// </summary>
        private static int preTotalWorkSheetCount = 0;//记录之前数据表的worsheet的数量

        /// <summary>
        /// 每个WorkSheet允许的行数
        /// </summary>
        private static int EverySheetRows = 3 * 100 * 100;


        /// <summary>
        /// 导出一个数据表的数据
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="filePath">包含文件名的文件路径</param>
        public static void ExportExcel(DataTable dataTable, string filePath)
        {
            try
            {
                Init();
                DataTableToExcel(dataTable, EverySheetRows);
                SaveAs(filePath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 导出多个数据表的数据
        /// </summary>
        /// <param name="dataSet">数据集(包含多个数据表)</param>
        /// <param name="filePath">包含文件名的文件路径</param>
        public static void ExportExcel(DataSet dataSet, string filePath)
        {
            try
            {
                Init();
                for (int i = 0; i < dataSet.Tables.Count; i++)
                {
                    DataTableToExcel(dataSet.Tables[i], EverySheetRows);
                }
                SaveAs(filePath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 清空工作簿上的工作表  但是会剩余一个[工作簿上至少要保留一个工作表]
        /// </summary>
        private static void ClearSheet()
        {
            try
            {
                int count = workBook.Sheets.Count;
                for (int i = 0; i < count - 1; i++)//此循环仅仅代表循环次数
                {
                    DeleteWorkSheet(workBook.Sheets.Count);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 初始化app,工作簿和工作表
        /// </summary>
        private static void Init()
        {
            app = new Application();
            app.Visible = false;
            app.DisplayAlerts = false;//覆盖非空单元格的时候，不提示
            app.AlertBeforeOverwriting = false;//另存为时，覆盖同名文件不提示
            workBook = app.Workbooks.Add(missing);
            ClearSheet();
        }

        /// <summary>
        /// 另存为   保存完之后，自动释放资源
        /// </summary>
        /// <param name="filePath"></param>
        private static void SaveAs(string filePath)
        {
            workSheet = workBook.Sheets.get_Item(1);//设置当前的工作表为第一个WorkSheet  [不需要判断，第一个WorkSheet必然存在]
            //必须转换一下，否则会提示Microsoft.Office.Interop.Excel.._Worksheet.Active()和Microsoft.Office.Interop.Excel.DocEvents_Event.Active之间存在二义性,将使用方法组.
            ((_Worksheet)workSheet).Activate();//确保使用Excel打开文件之后，显示的是第一个

            if (filePath == null)
            {
                return;
            }
            XlFileFormat fileFormat;
            if (Path.GetExtension(filePath).Equals(".xlsx"))
            {
                fileFormat = XlFileFormat.xlWorkbookDefault; //Excel 2007版本 
            }
            else
            {
                throw new Exception("文件格式错误");
            }
            try
            {
                workBook.SaveAs(filePath, fileFormat, missing, missing, missing, missing, XlSaveAsAccessMode.xlExclusive, missing, missing, missing, missing, missing);
            }
            catch
            {
                throw;
            }
            finally
            {
                Dispose();
            }
        }

        /// <summary>
        /// 将DataTable导出到Excel
        /// </summary>
        /// <param name="table">数据表</param>
        /// <param name="rowsPerSheet">每rowsPerSheet个数据分一页</param>
        private static void DataTableToExcel(DataTable table, int rowsPerSheet)
        {
            int i = 0;//工作表的索引
            int j = 0;//table的行索引
            int k = 0;//列索引
            try
            {
                if (table.TableName.Equals(string.Empty))
                {
                    throw new Exception("数据表的表名不能为空");
                }
                if (rowsPerSheet <= 0 || rowsPerSheet > 65535)
                {
                    throw new Exception("工作表所允许的数据行必须大于0并且小于等于65535");
                }
                if (table.Columns.Count > 255)
                {
                    throw new Exception("数据表的列数必须小于等于255");
                }
                int rowsCount = table.Rows.Count;//当前表的数据行数
                sheetCount = CalculateSheetCount(rowsCount, rowsPerSheet);
                preTotalWorkSheetCount = totalSheetCount;
                totalSheetCount = totalSheetCount + sheetCount;
                if (sheetCount + workBook.Sheets.Count > 255)
                {
                    throw new Exception("数据量太大,请减少行数");
                }
                InitWorkSheet();
                i = workSheet.Index;
                for (; i <= workBook.Sheets.Count; i++)//遍历之前生成的工作表，进行数据的赋值
                {
                    workSheet = workBook.Sheets.get_Item(i);
                    if (sheetCount > 1)
                    {
                        workSheet.Name = string.Format("{0}-{1}", table.TableName, i - preTotalWorkSheetCount);
                    }
                    else
                    {
                        workSheet.Name = table.TableName;
                    }
                    j = 0;
                    for (; j < rowsPerSheet; j++)//遍历行
                    {
                        if ((i - 1 - preTotalWorkSheetCount) * rowsPerSheet + j < rowsCount)//确保数据(i-1) * rowsPerSheet+j不会超出Table表的行数
                        {
                            k = 0;
                            for (; k < table.Columns.Count; k++)//遍历列
                            {
                                workSheet.Cells[k + 1][j + 1] = table.Rows[j + (i - 1 - preTotalWorkSheetCount) * rowsPerSheet][k].ToString();//需要注意的是,Excel的单元格索引,是从1开始的
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Dispose();
                throw ex;
            }
        }

        /// <summary>
        /// 初始化工作表(根据需要的工作表的数量来添加或者移除工作表)
        /// </summary>
        /// <param name="sheetCount"></param>
        private static void InitWorkSheet()
        {
            if (sheetCount <= 0)
            {
                throw new Exception("工作表的数量错误");
            }
            if (totalSheetCount == 1)//如果需要的工作表的数量仅仅是1的话，那么默认的第一张表就可以拿来直接使用
            {
                workSheet = workBook.Sheets.get_Item(1);
            }
            else
            {
                workSheet = workBook.Sheets.get_Item(workBook.Sheets.Count);//获取当前工作簿中最后一张工作表
                workBook.Sheets.Add(missing, workSheet, totalSheetCount - workBook.Sheets.Count, missing);//在当前最后一张工作表后新增totalSheetCount - workBook.Sheets.Count工作表
                workSheet = workBook.Sheets.get_Item(totalSheetCount - sheetCount + 1);//workSheet设置为新增的第一张工作表
            }
        }

        /// <summary>
        /// 根据索引删除工作表
        /// </summary>
        /// <param name="sheetIndex"></param>
        private static void DeleteWorkSheet(int sheetIndex)
        {
            try
            {
                if (sheetIndex > workBook.Sheets.Count)
                {
                    throw new Exception("索引超出范围，WorkSheet索引不能大于WorkSheet数量！");
                }
                Worksheet sheet = null;
                sheet = (Worksheet)workBook.Sheets.get_Item(sheetIndex);
                sheet.Delete();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 计算需要的工作表的数量
        /// </summary>
        /// <param name="totalRows"></param>
        /// <param name="sheetRows"></param>
        /// <returns></returns>
        private static int CalculateSheetCount(int totalRows, int sheetRows)
        {
            double result = Convert.ToDouble(totalRows) / Convert.ToDouble(sheetRows);
            return Convert.ToInt32(Math.Ceiling(result));//向上取整
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        private static void Dispose()
        {
            int appHwnd = app.Hwnd;
            try
            {
                workBook.Close(true, missing, missing);
                app.Workbooks.Close();
                app.Quit();
                if (workSheet != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(workSheet);
                    workSheet = null;
                }
                if (workBook != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(workBook);
                    workBook = null;
                }
                if (app != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                    app = null;
                }
            }
            catch
            {

            }
            GC.Collect();
            KillExcelProcess(appHwnd);

        }

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);
        /// <summary>
        /// Kill掉之前创建的excel进程
        /// </summary>
        /// <param name="appHwnd"></param>
        private static void KillExcelProcess(int appHwnd)
        {
            Process[] ps = Process.GetProcesses();
            IntPtr t = new IntPtr(appHwnd); //得到这个句柄，具体作用是得到这块内存入口 
            int ExcelID = 0;
            GetWindowThreadProcessId(t, out ExcelID); //得到本进程唯一标志k
            foreach (Process p in ps)
            {
                if (p.ProcessName.ToLower().Equals("excel"))
                {
                    if (p.Id == ExcelID)
                    {
                        p.Kill();
                    }
                }
            }
        }
    }
}
