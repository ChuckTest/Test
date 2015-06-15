using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReflectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ObjectGetType();
            TypeGetType();
            TypeOfOperator();
            Console.ReadKey();
        }

        /// <summary>
        /// This method returns a Type object that represents the type of an instance. Obviously, this approach will only work if you have compile-time knowledge of the type.
        /// </summary>
        static void ObjectGetType()
        {
            Car car = new Car();
            Type type = car.GetType();
            Console.WriteLine(type.FullName);
            Console.WriteLine();
        }

        /// <summary>
        ///Another way of getting type information in a more flexible manner is 
        ///the GetType() static method of the Type class which gets the type with the specified name,performing a case-sensitive search.
        ///Type.GetType() is an overloaded method that accepts the following parameters:
        ///1.fully qualified string name of the type you are interested in examining
        ///2.exception that should be thrown if the type cannot be found
        ///3.establishes the case sensitivity of the string
        /// </summary>
        static void TypeGetType()
        {
            string typeName = "Reflection.DemoCar";
            Type type = Type.GetType(typeName, false, true);
            ConsoleResult(type, typeName);

            typeName = "ReflectionDemo.Car";
            type = Type.GetType(typeName, false, true);
            ConsoleResult(type, typeName);
            Console.WriteLine();
        }

        static void ConsoleResult(Type type, string typeName)
        {
            if (type != null)
            {
                Console.WriteLine(type.FullName);
            }
            else
            {
                Console.WriteLine("Can not find the type {0}", typeName);
            }
        }

        static void TypeOfOperator()
        {
            Type type = typeof(Car);
            Console.WriteLine(type.FullName);
            Console.WriteLine();
        }
    }
}
