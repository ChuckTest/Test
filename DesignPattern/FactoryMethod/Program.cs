using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Creator creator;//客户端拥有一个抽象Creator的引用
            Parent parent;//客户端不确定返回的类型,所以需要用父类来接收创建出来的对象

            creator = new CreatorA();//通过Creator的子类来实例化
            parent = creator.Create();

            creator = new CreatorB();
            parent = creator.Create();

            Console.ReadKey();
        }
    }
}
