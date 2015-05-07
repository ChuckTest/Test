using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class ChildB : Parent
    {
        internal ChildB()
        {
            Console.WriteLine("创建ChildB的实例");
        }
    }
}
