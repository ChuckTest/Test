using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractFactory abstractFactory;
            ProductA productA;
            ProductB productB;

            abstractFactory = new Factory1();
            productA = abstractFactory.CreateProductA();
            productB = abstractFactory.CreateProductB();

            abstractFactory = new Factory2();
            productA = abstractFactory.CreateProductA();
            productB = abstractFactory.CreateProductB();

            Console.ReadKey();
        }
    }
}
