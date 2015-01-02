using System;

namespace ConcurrentDictionaryDemo
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(string.Format("ConcurrentDictionary测试开始"));
            Constructor.Test();
            AddOrUpdate.Test();
            Console.WriteLine(string.Format("ConcurrentDictionary测试结束"));
            Console.ReadKey();
        }
    }
}
