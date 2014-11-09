using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparingPatterns
{
    class MyClass
    {
        /// <summary>
        /// a Read method that reads a specified amount of data into a provided buffer starting at a specified offset
        /// 从buffer字节数组中的第offset位置开始，向后读取count个字节
        /// </summary>
        /// <param name="buffer">源数组数组</param>
        /// <param name="offfset">读取的起始位置(从0开始的偏移量)</param>
        /// <param name="count">读取几个字节</param>
        /// <returns></returns>
        public int Read(byte[] buffer, int offfset, int count)
        {
            return 0;
        }
    }
    
}
