using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class CreatorB : Creator
    {
        internal override Parent Create()
        {
            ChildB childB = new ChildB();
            return childB;
        }
    }
}
