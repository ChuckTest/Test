using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Builder.Product;

namespace Builder.Builder
{
    /// <summary>
    /// The MonkeyBuilder class is a child class of AnimalBuilder. It provides the details of each building method for a Monkey. 
    /// In this class, we apply all the rules to make our product (Monkey) a ready to use object (decorated monkey). 
    /// In the constructor, we also initialize the Animal object (aAnimal) to be a Monkey object.
    /// </summary>
    class MonkeyBuilder:AnimalBuilder
    {
        public MonkeyBuilder()
        {
            animal = new Monkey();
        }

        public override void BulidHead()
        {
            animal.Head = "Moneky's Head has been built";
        }

        public override void BulidBody()
        {
            animal.Body = "Moneky's Body has been built";
        }

        public override void BulidArm()
        {
            animal.Arm = "Moneky's Arm has been built";
        }

        public override void BulidLeg()
        {
            animal.Leg = "Moneky's Leg has been built";
        }

        public override void BulidTail()
        {
            animal.Tail = "Moneky's Tail has been built";
        }
    }
}
