using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Factory2 : AbstractFactory
    {
        internal override ProductA CreateProductA()
        {
            return new ProductA2();
        }

        internal override ProductB CreateProductB()
        {
            return new ProductB2();
        }
    }
}
