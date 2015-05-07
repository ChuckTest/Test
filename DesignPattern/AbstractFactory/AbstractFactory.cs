using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    abstract class AbstractFactory
    {
        internal abstract ProductA CreateProductA();
        internal abstract ProductB CreateProductB();
    }
}
