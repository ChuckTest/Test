using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class Context
    {
        private Strategy strategy;

        internal Context(Strategy s)
        {
            strategy = s;
        }

        internal void Sort()
        {
            strategy.Sort();
        }
    }
}
