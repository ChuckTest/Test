using System;

namespace AttributeDemo
{
    class AnimalTypeAttribute : Attribute
    {
        public AnimalTypeAttribute(Animal animal)
        {
            pet = animal;
        }

        protected Animal pet;
        public Animal Pet
        {
            get { return pet; }
            set { pet = value; }
        }
    }
}
