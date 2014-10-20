using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    /// <summary>
    /// 自己做饭的情况
    /// 没有简单工厂之前，客户想吃什么菜，只能自己炒
    /// </summary>
    class Customer
    {
        public static Food Cook(string type)
        {
            Food food = null;
            if (type.Equals("西红柿炒蛋"))
            {
                food = new TomatoScrambledEggs();
            }
            else if (type.Equals("红烧鱼"))
            {
                food = new Fish();
            }
            return food;
        }

        static void Main(string[] args)
        {
            Food food1 = Cook("西红柿炒蛋");
            food1.Print();

            Food food2 = Cook("红烧鱼");
            food2.Print();

            Console.WriteLine();

            food1 = FoodFactory.CreateFood("红烧鱼");
            food1.Print();

            food2 = FoodFactory.CreateFood("西红柿炒蛋");
            food2.Print();

            Console.Read();
        }
    }

    /// <summary>
    /// 菜的抽象类
    /// </summary>
    public abstract class Food
    {
        /// <summary>
        /// 输出点了什么菜
        /// </summary>
        public abstract void Print();
    }

    /// <summary>
    /// 西红柿炒蛋这道菜
    /// </summary>
    public class TomatoScrambledEggs : Food
    {
        public override void Print()
        {
            Console.WriteLine("一份西红柿炒鸡蛋");
        }
    }

    /// <summary>
    /// 红烧鱼这道菜
    /// </summary>
    public class Fish : Food
    {
        public override void Print()
        {
            Console.WriteLine("一份红烧鱼");
        }
    }

    /// <summary>
    /// 简单工厂类,负责炒菜
    /// </summary>
    public class FoodFactory
    {
        public static Food CreateFood(string type)
        {
            Food food = null;
            if (type.Equals("西红柿炒蛋"))
            {
                food = new TomatoScrambledEggs();
            }
            else if (type.Equals("红烧鱼"))
            {
                food = new Fish();
            }
            return food;
        }
    }
}
