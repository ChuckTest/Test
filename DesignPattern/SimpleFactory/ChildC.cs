using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory
{
    class ChildC : Parent
    {
        internal ChildC()
        {
            Console.WriteLine("创建ChildC的实例");
        }
    }
}
