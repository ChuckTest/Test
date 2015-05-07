using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class ProductA
    {
    }

    class ProductA1 : ProductA
    {
        internal ProductA1()
        {
            Console.WriteLine("创建ProductA1");
        }
    }

    class ProductA2 : ProductA
    {
        internal ProductA2()
        {
            Console.WriteLine("创建ProductA2");
        }
    }
}
