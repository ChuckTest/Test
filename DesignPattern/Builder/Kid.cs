using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Builder.Builder;

namespace Builder
{
    class Kid
    {
        public string Name { get; set; }

        //construct process to build an animal object, 
        //after this process completed, a object 
        //will be consider as a ready to use object.
        public void MakeAnimal(AnimalBuilder animalBuilder)
        {
            animalBuilder.BulidHead();
            animalBuilder.BulidBody();
            animalBuilder.BulidArm();
            animalBuilder.BulidLeg();
            animalBuilder.BulidTail();
        }
    }
}
