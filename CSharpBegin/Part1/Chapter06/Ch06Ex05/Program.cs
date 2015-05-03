using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch06Ex05
{
    class Program
    {
        //委托的声明非常类似于函数，但不带函数体，且要使用delegate关键字。
        //委托的声明指定了一个返回类型和一个参数列表。
        delegate double ProcessDelegate(double a, double b);//返回类型是double,参数列表：两个double变量a和b
        static double Multiply(double x, double y)
        {
            return x * y;
        }

        static double Divide(double m, double n)
        {
            return m / n;
        }

        public static void Main(string[] args)
        {
            ProcessDelegate process;//在定义了委托后，就可以声明该委托类型的变量。
            process = new ProcessDelegate(Multiply);//把委托变量初始化为与委托有相同返回类型和参数列表的函数引用。
            Console.WriteLine("Multiply(100,10)={0}", process(100, 10));//使用委托变量调用这个函数，就像该变量是一个函数一样

            process = new ProcessDelegate(Divide);//把委托变量初始化为与委托有相同返回类型和参数列表的函数引用。
            process(100, 10);//使用委托变量调用这个函数，就像该变量是一个函数一样
            Console.WriteLine("Divide(100,10)={0}", process(100, 10));

            Console.ReadKey();
        }
    }
}
