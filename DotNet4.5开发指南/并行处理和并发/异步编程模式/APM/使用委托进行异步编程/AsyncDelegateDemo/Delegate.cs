using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDelegateDemo
{
    public delegate bool AsyncFactorCaller(int number,ref int primeFactor1,ref int primeFactor2);
}
