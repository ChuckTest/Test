using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Product
{
    /// <summary>
    /// The Monkey class is a concrete product class that will be built from a MonkeyBuilder.
    /// </summary>
    public class Monkey : Animal
    {
        //helper method to show monkey's property for demo purpose
        public override void Eat()
        {
            Console.WriteLine("Since I am Monkey, I like to eat banana");
        }
    }
}
