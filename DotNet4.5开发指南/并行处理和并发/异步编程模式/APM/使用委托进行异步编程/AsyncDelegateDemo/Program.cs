using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDelegateDemo
{
    /// <summary>
    /// Asynchronous Delegates Programming Sample异步委托编程示例
    /// http://msdn.microsoft.com/zh-cn/library/h80ttd5f(v=vs.110).aspx
    /// http://msdn.microsoft.com/en-us/library/h80ttd5f(v=vs.110).aspx
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            DemonstrateAsyncPattern demonstrator = new DemonstrateAsyncPattern();
            demonstrator.FactorizeNumberUsingCallback();
            demonstrator.FactorizeNumberAndWait();
            Console.ReadLine();
        }
    }
}
