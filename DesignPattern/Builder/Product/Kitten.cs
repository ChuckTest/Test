using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Product
{
    /// <summary>
    /// Same as the Monkey class, a concrete product class that will be built from a Kittenbuilder.
    /// </summary>
    public class Kitten : Animal
    {
        public override void Eat()
        {
            Console.WriteLine("Since I am Kitten, I like to eat kitten food");
        }
    }
}
