using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertHelperDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //string hexString = "Abcdef0103dac3";
                //byte[] array = ConvertHelper.HexStringToByteArray(hexString);
                //for (int i = 0; i < array.Length; i++)
                //{
                //    Console.Write("{0,3},",array[i]);
                //}



                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("捕获异常信息：{0}", ex.Message));
            }
            Console.ReadKey();
        }
    }
}
