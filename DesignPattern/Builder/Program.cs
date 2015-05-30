using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Builder.Builder;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            AnimalBuilder animalBuilder;
            Kid kid = new Kid
            {
                Name = "Elizabeth"
            };

            Console.WriteLine("{0} start making a monkey", kid.Name);
            animalBuilder = new MonkeyBuilder();
            kid.MakeAnimal(animalBuilder);
            animalBuilder.animal.ShowMe();

            Console.WriteLine();

            Console.WriteLine("{0} start making a kitten", kid.Name);
            animalBuilder = new KittenBuilder();
            kid.MakeAnimal(animalBuilder);
            animalBuilder.animal.ShowMe();

            Console.ReadKey();

        }
    }
}
