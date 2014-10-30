using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonTest.Log;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using DataTable = System.Data.DataTable;
namespace CommonTest.Exccel
{
    class ExcelHelper
    {
        private Application app;//excel应用
        private Workbook workBook;//工作簿
        private Worksheet currentWorkSheet;//工作表
        private Range range;//单元格区域
        private object missing = Missing.Value;
        /// <summary>
        /// 导出的Excel的文件保存路径
        /// </summary>
        private string outputFile;
        private int sheetCount = 1;   //WorkSheet数量

        private int rows = 30000;//默认每一个工作表的数量是30000

        public int RowsCountEveryWorkSheet
        {
            set { rows = value; }
        }

        /// <summary>
        /// 不允许外部调用无参构造函数
        /// </summary>
        private ExcelHelper() { }

        /// <summary>
        /// 构造函数，新建一个工作簿
        /// </summary>
        public ExcelHelper(string filePath)
        {
            app = new ApplicationClass() { Visible = false };//新建一个Excel的App
            workBook = app.Workbooks.Add(Type.Missing);//新建一个工作簿
            currentWorkSheet = (Worksheet)workBook.Sheets.get_Item(1);//让currentWorkSheet指向工作簿中的第一个工作表
            outputFile = filePath;//获取保存文件的路径
        }

        /// <summary>
        /// 给工作簿加一个新的工作表，并使currentWorkSheet指向新表
        /// </summary>
        public void CreateWorkSheet()
        {
            Worksheet lastWorkSheet = (Worksheet)workBook.Sheets.get_Item(workBook.Sheets.Count);//获取工作簿中最后一个工作表
            currentWorkSheet = (Worksheet)workBook.Sheets.Add(missing, lastWorkSheet, 1, missing);//新增一个工作表,并将新表赋给currentWorkSheet
        }

        /// <summary>
        /// 将DataTable数据写入Excel文件（自动分页）
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="rows">每个WorkSheet写入多少行数据</param>
        public void DataTableToExcel(DataTable dt)
        {
            int startRow;//记录起始行索引 
            int endRow;//记录结束行索引
            int row;//当前需要写入worksheet的数据行数
            int rowCount = dt.Rows.Count; //DataTable行数
            int colCount = dt.Columns.Count; //DataTable列数
            sheetCount = GetSheetCount(rowCount, rows); //WorkSheet个数

            //复制sheetCount-1个WorkSheet对象
            if (sheetCount > 1)
            {
                workBook.Sheets.Add(missing, currentWorkSheet, sheetCount - 1, missing);
            }

            int initialIndex = currentWorkSheet.Index;
            for (int i = 0; i < sheetCount; i++)
            {
                startRow = i * rows;
                if (i == sheetCount - 1)//若是最后一个WorkSheet，那么记录结束行索引为源DataTable行数
                {
                    endRow = rowCount - 1;
                }
                else
                {
                    endRow = (i + 1) * rows - 1;
                }

                //获取要写入数据的WorkSheet对象，并重命名
                currentWorkSheet = (Worksheet)workBook.Worksheets.get_Item(initialIndex + i);
                if (sheetCount > 1)
                {
                    currentWorkSheet.Name = String.Format("{0}-{1}", dt.TableName, i + 1);
                }
                else
                {
                    currentWorkSheet.Name = dt.TableName;
                }

                row = endRow - startRow + 1;
                object[,] ss = new object[row + 1, colCount];

                for (int j = 0; j <= row; j++)
                {
                    for (int k = 0; k < colCount; k++)
                    {
                        if (j == 0)
                        {
                            ss[j, k] = dt.Columns[k].ColumnName;
                        }
                        else
                        {
                            if (dt.Columns[k].ColumnName.Equals("时间"))
                            {
                                ss[j, k] = Convert.ToDateTime(dt.Rows[startRow + j - 1][k]).ToString("s").Replace('T', '/');
                            }
                            else
                            {
                                ss[j, k] = dt.Rows[startRow + j - 1][k];
                            }
                        }
                    }
                }

                range = (Range)currentWorkSheet.Cells[1, 1];
                range = range.get_Resize(row + 1, colCount);
                range.Value2 = ss;
                range.EntireColumn.AutoFit();
                range.VerticalAlignment = XlVAlign.xlVAlignBottom;
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            }
        }

        /// <summary>
        /// 计算WorkSheet数量
        /// </summary>
        /// <param name="rowCount">记录总行数</param>
        /// <param name="rows">每WorkSheet行数</param>
        public static int GetSheetCount(int rowCount, int rows)
        {
            return Convert.ToInt32(Math.Ceiling(Convert.ToDouble(rowCount) / Convert.ToDouble(rows)));//两数相除，然后向上取整
        }

        /// <summary>
        /// 根据名称删除工作表
        /// </summary>
        /// <param name="sheetName"></param>
        public void DeleteWorkSheet(string sheetName)
        {
            try
            {
                for (int i = 1; i <= workBook.Sheets.Count; i++)//遍历工作簿中的所有工作表
                {
                    currentWorkSheet = (Worksheet)workBook.Sheets.get_Item(i);
                    if (currentWorkSheet.Name.IndexOf(sheetName) >= 0)//如果工作表的表明包含sheetName
                    {
                        currentWorkSheet.Delete();//删除
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionLog.Instance.WriteLog(ex, LogType.UI);
                Dispose();
                throw ex;
            }
        }

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        private static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);
        /// <summary>
        /// Kill掉之前创建的excel进程
        /// </summary>
        /// <param name="appHwnd"></param>
        private static void KillExcelProcess(int appHwnd)
        {
            Process[] ps = Process.GetProcesses();
            IntPtr t = new IntPtr(appHwnd); //得到这个句柄，具体作用是得到这块内存入口 
            int ExcelID = 0;
            GetWindowThreadProcessId(t, out ExcelID); //得到本进程唯一标志
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

        /// <summary>
        /// 保存文件
        /// </summary>
        public void SaveAsFile()
        {
            if (outputFile == null)
            {
                throw new Exception("没有指定输出文件路径！");
            }

            XlFileFormat fileFormat;
            if (String.Compare(Path.GetExtension(outputFile).ToLower(), ".xlsx", false) == 0)
            {
                fileFormat = XlFileFormat.xlWorkbookDefault; //Excel 2007版本 
            }
            else
            {
                fileFormat = XlFileFormat.xlAddIn8;//Excel 2003版本 
            }

            try
            {
                workBook.SaveAs(outputFile, fileFormat, missing, missing, missing, missing, XlSaveAsAccessMode.xlExclusive, missing, missing, missing, missing, missing);
            }
            catch (Exception ex)
            {
                ExceptionLog.Instance.WriteLog(ex, LogType.UI);
                throw;
            }
            finally
            {
                Dispose();
            }
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        private void Dispose()
        {
            int appHwnd = 0;
            try
            {
                if (currentWorkSheet != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(currentWorkSheet);
                    currentWorkSheet = null;
                }
                if (workBook != null)
                {
                    workBook.Close(true, missing, missing);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(workBook);
                    workBook = null;
                }
                if (app != null)
                {
                    appHwnd = app.Hwnd;
                    app.Workbooks.Close();
                    app.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                    app = null;
                }
            }
            catch (Exception ex)
            {
                ExceptionLog.Instance.WriteLog(ex, LogType.UI);
                throw ex;
            }
            GC.Collect();
            if (appHwnd > 0)
            {
                KillExcelProcess(appHwnd);
            }
        }
    }
}
