using System;
using System.Reflection;

namespace AttributeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            AnimalTypeTest animalTypeTest = new AnimalTypeTest();
            Type type = animalTypeTest.GetType();

            MethodInfo[] methodInfoArray = type.GetMethods();
            foreach (MethodInfo methodInfo in methodInfoArray)
            {
                Attribute[] attributeArray = Attribute.GetCustomAttributes(methodInfo);
                foreach (Attribute attribute in attributeArray)
                {
                    AnimalTypeAttribute animalTypeAttribute = attribute as AnimalTypeAttribute;
                    if (animalTypeAttribute != null)
                    {
                        Console.WriteLine(string.Format("{0} {1}", methodInfo.Name, animalTypeAttribute.Pet));
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
