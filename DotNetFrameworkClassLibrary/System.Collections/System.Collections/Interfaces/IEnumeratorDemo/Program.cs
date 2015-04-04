using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumeratorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Person[] array =
            {
                new Person("John","Smith"), 
                new Person("Jim","Johnson"),
                new Person("Sue","Rabon")
            };

            People list = new People(array);
            foreach (Person item in list)
            {
                Console.WriteLine(
                    string.Format("firstName:{0},lastName:{1}",
                    item.firstName,
                    item.lastName));
            }
            Console.ReadKey();
        }
    }
}
