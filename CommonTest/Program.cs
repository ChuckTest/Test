﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonTest
{
    class Program
    {
        /// <summary>
        /// 主函数
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Exccel.LoadExcel.Method(@"D:\Software\ZBMYun\SourceCode\ZITaker\Utility\bin\Debug\Excel\20141027_150903.xlsx");
            Console.Read();
        }
    }
}
