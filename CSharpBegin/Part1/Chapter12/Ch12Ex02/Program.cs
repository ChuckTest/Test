using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch12Ex02
{
    class Program
    {
        /// <summary>
        /// 与Ch11Ex02的区别:项目中不再有Animals类，改为使用泛型类List<T>
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            List<Animal> animalCollection = new List<Animal>();
            animalCollection.Add(new Cow("Jack"));
            animalCollection.Add(new Chicken("Vera"));
            foreach (var item in animalCollection)
            {
                item.Feed();
            }
            Console.ReadKey();
        }
    }
}
