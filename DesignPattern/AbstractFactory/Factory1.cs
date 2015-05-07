using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Factory1 : AbstractFactory
    {
        internal override ProductA CreateProductA()
        {
            return new ProductA1();
        }

        internal override ProductB CreateProductB()
        {
            return new ProductB1();
        }
    }
}
