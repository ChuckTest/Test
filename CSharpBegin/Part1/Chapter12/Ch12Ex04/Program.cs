using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch12Ex04
{
    class Program
    {
        static void Main(string[] args)
        {
            Farm<Animal> farm = new Farm<Animal>();
            farm.Animals.Add(new Cow("Jack"));
            farm.Animals.Add(new Chicken("Vera"));
            farm.Animals.Add(new Chicken("Sally"));
            farm.Animals.Add(new SuperCow("Kevin"));
            farm.MakeNoises();

            Console.WriteLine();

            Farm<Cow> dairyFarm = farm.GetCows();
            dairyFarm.FeedTheAnimals();

            Console.WriteLine();

            foreach (var item in dairyFarm)
            {
                if (item is SuperCow)
                {
                    (item as SuperCow).Fly();
                }
            }

            Console.ReadKey();
        }
    }
}
