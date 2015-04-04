using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Ch11Ex03
{
    class Primes
    {
        private long min;
        private long max;

        public Primes(long minimum, long maximum)
        {
            if (min < 2)
            {
                min = 2;
            }
            else
            {
                min = minimum;
            }
            max = maximum;
        }

        public Primes()
            : this(2, 100)
        { }

        public IEnumerator GetEnumerator()
        {
            for (long posssiblePrime = min; posssiblePrime <= max; posssiblePrime++)
            {
                bool isPrime = true;
                long tmpMax=(long)Math.Floor(Math.Sqrt(posssiblePrime));
                for (long possibleFactor = 2; possibleFactor <= tmpMax; possibleFactor++)
                {
                    long remainderAfterDivision = posssiblePrime % possibleFactor;
                    if (remainderAfterDivision == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    yield return posssiblePrime;
                }
            }
        }
    }
}
