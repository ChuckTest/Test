using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch11Ex04
{
    interface IMyInterface
    { }
    class ClassA : IMyInterface
    { }
    class ClassB : IMyInterface
    { }
    class ClassC
    { }
    class ClassD : ClassA
    { }
    struct MyStruct : IMyInterface
    { }

    class Program
    {
        static void Check(object param)
        {
            if (param is ClassA)
            {
                Console.WriteLine("Variable can be converted to ClassA.");
            }
            else
            {
                Console.WriteLine("Variable can't be converted to ClassA.");
            }

            if (param is IMyInterface)
            {
                Console.WriteLine("Variable can be converted to IMyInterface.");
            }
            else
            {
                Console.WriteLine("Variable can't be converted to IMyInterface.");
            }

            if (param is MyStruct)
            {
                Console.WriteLine("Variable can be converted to MyStruct.");
            }
            else 
            {
                Console.WriteLine("Variable can't be converted to MyStruct.");
            }
        }

        static void Main(string[] args)
        {
            ClassA try1 = new ClassA();
            ClassB try2 = new ClassB();
            ClassC try3 = new ClassC();
            ClassD try4 = new ClassD();
            MyStruct try5 = new MyStruct();

            //只有MyStruct类型的变量本身和该类型的封箱变量与MyStruct兼容，因为不能把引用类型转换为值类型
            object try6 = try5;

            //相当于把子类赋值给父类变量
            object try7 = try4;

            Console.WriteLine("Analyzing ClassA type variable:");
            Check(try1);

            Console.WriteLine("\nAnalyzing ClassB type variable:");
            Check(try2);
            Console.WriteLine("\nAnalyzing ClassC type variable:");
            Check(try3);
            Console.WriteLine("\nAnalyzing ClassD type variable:");
            Check(try4);
            Console.WriteLine("\nAnalyzing MyStruct type variable:");
            Check(try5);
            Console.WriteLine("\nAnalyzing boxed MyStruct type variable:");
            Check(try6);
            Console.WriteLine("\nAnalyzing boxed ClassD type variable:");
            Check(try7);
            Console.ReadKey();
        }
    }
}
