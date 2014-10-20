using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            int[] comID = CPortID.GetPortID();
            for (int i = 0; i < comID.Length; i++)
            {
                Console.WriteLine(comID[i]);
            }
            Console.Read();
        }
    }
}
