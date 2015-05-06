using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory
{
    /// <summary>
    /// 作为客户端(Client)类来调用简单工厂
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Parent parent = null;
            parent = SimpleFactory.Create(ChildType.A);
            parent = SimpleFactory.Create(ChildType.B);
            parent = SimpleFactory.Create(ChildType.C);
            Console.ReadKey();
        }
    }
}
