using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch12Ex04
{
    class SuperCow : Cow
    {
        public void Fly()
        {
            Console.WriteLine("{0} is flying!", name);
        }

        public SuperCow(string newName)
            : base(newName)
        {
        }

        public override void MakeANoise()
        {
            Console.WriteLine("{0} says 'here i come to save the day!'", name);
        }
    }
}
