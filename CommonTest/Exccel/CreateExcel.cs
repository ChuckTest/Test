using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using MessageBox = System.Windows.Forms.MessageBox;
namespace CommonTest.Exccel
{
    class CreateExcel
    {
        public static void Method()
        {
            try
            {
                Application xlApp;
                Workbook xlWorkBook;
                Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);

                xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
                xlWorkSheet.Cells[1, 1] = "http://csharp.net-informations.com";

                xlWorkBook.SaveAs("csharp-Excel.xls", XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);

                MessageBox.Show("Excel file created , you can find the file 我的文档下有 csharp-Excel.xls");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
