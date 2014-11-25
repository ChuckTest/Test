using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDelegateDemo
{
    class PrimeFactorFinder
    {
        /// <summary>
        /// 把一个整数分解成两个或更多的除1外的整数相乘的过程
        /// </summary>
        /// <param name="number"></param>
        /// <param name="primeFactor1"></param>
        /// <param name="primeFactor2"></param>
        /// <returns></returns>
        public static bool Factorize(int number, ref int primeFactor1, ref int primeFactor2)
        {
            primeFactor1 = 1;
            primeFactor2 = number;
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    primeFactor1 = i;
                    primeFactor2 = number / i;
                    break;
                }
            }
            if (primeFactor1 == 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
