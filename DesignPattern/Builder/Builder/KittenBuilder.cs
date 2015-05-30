using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Builder.Product;

namespace Builder.Builder
{
    /// <summary>
    /// Same as MonkeyBuilder, the KittenBuilder class will implement the details for building a Kitten object.
    /// </summary>
    class KittenBuilder : AnimalBuilder
    {
        public KittenBuilder()
        {
            animal = new Kitten();
        }

        public override void BulidHead()
        {
            animal.Head = "Kitten's Head has been built";
        }

        public override void BulidBody()
        {
            animal.Body = "Kitten's Body has been built";
        }

        public override void BulidArm()
        {
            animal.Arm = "Kitten's Arm has been built";
        }

        public override void BulidLeg()
        {
            animal.Leg = "Kitten's Leg has been built";
        }

        public override void BulidTail()
        {
            animal.Tail = "Kitten's Tail has been built";
        }
    }
}
