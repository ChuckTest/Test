using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory
{
    class ChildA : Parent
    {
        internal ChildA()
        {
            Console.WriteLine("创建ChildA的实例");
        }
    }
}
