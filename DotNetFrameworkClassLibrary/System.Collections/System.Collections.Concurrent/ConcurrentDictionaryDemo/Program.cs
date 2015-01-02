using System;

namespace ConcurrentDictionaryDemo
{
    class Program
    {
        static void Main()
        {
            try
            {
                Console.WriteLine(string.Format("ConcurrentDictionary测试开始"));
                Constructor.Test();
                AddOrUpdate.Test();
                FirstOrDefault.Test();
                Console.WriteLine(string.Format("ConcurrentDictionary测试结束"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
