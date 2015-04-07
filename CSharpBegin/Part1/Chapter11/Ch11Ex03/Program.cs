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
            try
            {
                Primes primes2To1000 = new Primes(Convert.ToInt64(Math.Pow(2, 61)), Convert.ToInt64(Math.Pow(2, 62)));
                foreach (long i in primes2To1000)
                {
                    Console.Write("{0}  ", i);
                }
            }
            catch (Exception ex)
            {
                Echo(ex);
            }
            Console.ReadKey();
        }

        static private void Echo(Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.TargetSite);
            Console.WriteLine(ex.StackTrace);
            if (ex.InnerException != null)
            {
                Console.WriteLine(ex.InnerException);
            }
            Console.WriteLine(ex.Source);
        }
    }
}
