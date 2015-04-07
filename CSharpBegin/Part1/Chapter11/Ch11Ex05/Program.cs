using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Ch11Ex05
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ArrayList list = new ArrayList();
                list.Add(new Person("Jim", 30));
                list.Add(new Person("Bob", 25));
                list.Add(new Person("Bert", 27));
                list.Add(new Person("Ernie", 22));

                Console.WriteLine("Unsorted people:");
                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine(string.Format("{0} {1}", (list[i] as Person).Name, (list[i] as Person).Age));
                }
                Console.WriteLine();

                list.Sort();
                Console.WriteLine("People sorted with default comparer (by age):");
                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine(string.Format("{0} {1}", (list[i] as Person).Name, (list[i] as Person).Age));
                }
                Console.WriteLine();

                list.Sort(PersonComparerName.Default);
                Console.WriteLine("People sorted with nondefault comparer (by name):");
                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine(string.Format("{0} {1}", (list[i] as Person).Name, (list[i] as Person).Age));
                }
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
