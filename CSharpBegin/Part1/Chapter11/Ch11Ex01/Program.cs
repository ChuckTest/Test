using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch11Ex01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Create an Array type collection of Animal objects and use it");
            Animal[] animalArray = new Animal[2];
            Cow myCow1 = new Cow("Deirdre");
            animalArray[0] = myCow1;
            animalArray[1] = new Chicken("Ken");
            foreach (Animal item in animalArray)
            {
                Console.WriteLine("New {0} object add to Array collection, Name = {1}",item.ToString(),item.Name);
            }
            Console.WriteLine("Array collection contains {0} objects.", animalArray.Length);
            animalArray[0].Feed();
            ((Chicken)animalArray[1]).LayEgg();
            Console.WriteLine();

            Console.WriteLine("Create an ArrayList type collection of Animal objects and use it:");
            ArrayList animalArrayList = new ArrayList();


            Console.ReadKey();
        }
    }
}
