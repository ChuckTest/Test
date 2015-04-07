using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing
{
    interface IMyInterface
    { }
    struct MyStructInterface : IMyInterface
    {
        public int Val;
    }
    struct MyStruct
    {
        public int Val;
    }
    class MyClass
    {
        public int Val;
    }

    /// <summary>
    /// 封箱是把值类型转换为System.Object类型 或者转换为由值类型实现的接口类型
    /// 
    /// 封箱是在没有用户干涉的情况下进行的(即不需要编写任何代码)
    /// 但拆箱一个值需要进行显示转换，即需要进行数据类型转换(封箱是隐式的，所以不需要进行数据类型转换)
    /// 
    /// 封箱的作用：
    /// 1.它允许使用集合中的值类型(如ArrayList)，集合中项的类型是object
    /// 2.有一个内部机制允许在值类型上调用object，例如int和结构
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            StructTest();
            ClassTest();
            InterfaceTest();
            Console.ReadKey();
        }
        
        /// <summary>
        /// 把值类型转换为System.Object类型
        /// </summary>
        static void StructTest()
        {
            MyStruct valType1 = new MyStruct();
            valType1.Val = 5;
            object refType = valType1;//以这种方式封箱而创建的对象，包含值类型变量的一个副本的引用，而不包含源值类型变量的引用。
            valType1.Val = 6;
            MyStruct valType2 = (MyStruct)refType;//拆箱
            Console.WriteLine("valType2.Val = {0}", valType2.Val);
        }

        static void ClassTest()
        {
            MyClass refType1 = new MyClass();
            refType1.Val = 5;
            object refType = refType1;
            refType1.Val = 6;
            MyClass refType2 = (MyClass)refType;
            Console.WriteLine("refType2.Val = {0}", refType2.Val);
        }

        /// <summary>
        /// 把值类型转换为由值类型[struct]实现的接口类型
        /// </summary>
        static void InterfaceTest()
        {
            MyStructInterface valType1 = new MyStructInterface();
            valType1.Val = 5;
            IMyInterface refType = valType1;
            valType1.Val = 6;
            MyStructInterface valType2 = (MyStructInterface)refType;
            Console.WriteLine("valType2.Val = {0}", valType2.Val);
        }
    }
}
