using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch11Ex03
{
    class Program
    {
        static void Main(string[] args)
        {
            Primes primes2To1000 = new Primes(2, 1000);
            foreach (long i in primes2To1000)
            {
                Console.Write("{0}  ",i);
            }
            Console.ReadKey();
        }
    }
}
