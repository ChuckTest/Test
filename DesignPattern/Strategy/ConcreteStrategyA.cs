﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class ConcreteStrategyA : Strategy
    {
        internal override void Sort()
        {
            Console.WriteLine("排序算法A");
        }
    }
}