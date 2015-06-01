using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Builder.Builder;

namespace Builder
{
    /// <summary>
    /// From the client side, I create a Kid (constructor object) named Elizabeth. 
    /// Elizabeth will use the monkey mold tool set to make a monkey, and she also uses the kitten mold toolkit to make a kitten. 
    /// From the client, you will see I can directly use builderA.animal as a ready to use object after it's been built (because it has the public property in the base AnimalBuilder class). 
    /// It might be a private field which has a public method to access it as well.
    /// </summary>
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
