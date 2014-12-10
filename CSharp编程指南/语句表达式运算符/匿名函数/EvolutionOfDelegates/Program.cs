using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionOfDelegates
{
    /// <summary>
    /// 定义一个委托
    /// </summary>
    /// <param name="s"></param>
    delegate void TestDelegate (string s);

    /// <summary>
    /// http://msdn.microsoft.com/en-us/library/bb882516(v=vs.110).aspx
    /// </summary>
    class Program
    {
        static void M(string s)
        {
            Console.WriteLine(s);
        }

        static void Main(string[] args)
        {
            // Original delegate syntax required initialization with a named method.
            TestDelegate a = new TestDelegate(M);

            //C# 2.0: A delegate can be initialized with inline code, called an "anonymous method." This method takes a string as an input parameter.
            TestDelegate b = delegate(string s) { Console.WriteLine(s); };

            // C# 3.0. A delegate can be initialized with a lambda expression. The lambda also takes a string as an input parameter (x). 
            //The type of x is inferred by the compiler.
            TestDelegate c = x => { Console.WriteLine(x); };

            a("Hello,My Name is M and I write lines.");
            b("That's nothing. I am anonymous method.");
            c("I am lambda expression");

            Console.ReadKey();

        }
    }
}
