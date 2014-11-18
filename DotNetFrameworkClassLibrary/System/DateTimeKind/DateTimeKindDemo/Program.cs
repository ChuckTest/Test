using System;

namespace DateTimeKindDemo
{
    /// <summary>
    /// DateTimeKind测试
    /// </summary>
    class Program
    {
        static readonly string dateTimeFormat = "yyyy-MM-dd HH:mm:ss";
        static void Main(string[] args)
        {
            DateTime now = DateTime.Now;
            DateTime utcNow = DateTime.UtcNow;
            Console.WriteLine(string.Format("Local时间{0}", now.ToString(dateTimeFormat)));
            Console.WriteLine(string.Format("UTC时间{0}", utcNow.ToString(dateTimeFormat)));

            Console.WriteLine();

            DateTime tmpTime;
            tmpTime = now.ToUniversalTime();
            Console.WriteLine(string.Format("Local时间转换为UTC时间 {0}", tmpTime.ToString(dateTimeFormat)));

            tmpTime = utcNow.ToLocalTime();
            Console.WriteLine(string.Format("UTC时间转换为Local时间 {0}", tmpTime.ToString(dateTimeFormat)));

            Console.WriteLine();

            //系统时区，为北京时间
            tmpTime = DateTime.SpecifyKind(now,DateTimeKind.Unspecified);
            //未指定时间的话，转换Local的时候，时间默认为UTC的，加上当前系统的时区的时差+8，也就是加上8个小时
            Console.WriteLine(string.Format("Unspecified时间转换为Local时间 {0}", tmpTime.ToLocalTime().ToString(dateTimeFormat)));
            //未指定时间的话，转换UTC的时候，时间默认为Local的，加上当前系统的时区的时差-8，也就是减去8个小时
            Console.WriteLine(string.Format("Unspecified时间转换为UTC时间 {0}", tmpTime.ToUniversalTime().ToString(dateTimeFormat)));

            Console.ReadLine();
        }
    }
}
