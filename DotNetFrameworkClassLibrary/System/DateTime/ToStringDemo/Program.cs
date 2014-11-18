using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ToStringDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime now = DateTime.Now;
            DateTime utcNow = now.ToUniversalTime();
            string time = string.Empty;

            time = now.ToString("s");
            Console.WriteLine(time);

            DateTime datetime = Convert.ToDateTime(time);
            time = datetime.ToString("s");
            Console.WriteLine(time);

            time = utcNow.ToString("s");
            Console.WriteLine(time);

            datetime = Convert.ToDateTime(time);
            time = datetime.ToString("s");
            Console.WriteLine(time);

            Console.WriteLine(System.Threading.Thread.CurrentThread.CurrentCulture.Name);

            Console.WriteLine(DateTimeFormatInfo.CurrentInfo);//这个是重点


            Console.ReadLine();
        }
    }
}
