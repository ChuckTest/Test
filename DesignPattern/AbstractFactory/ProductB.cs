using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class ProductB
    {
    }

    class ProductB1 : ProductB
    { 
        internal ProductB1()
        {
            Console.WriteLine("创建ProductB1");
        }
    }

    class ProductB2 : ProductB
    {  
        internal ProductB2()
        {
            Console.WriteLine("创建ProductB2");
        }
    }
}
