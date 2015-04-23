using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Ch12Ex04
{
    /// <summary>
    /// 创建了一个泛型类Farm，它没有继承泛型List类
    /// 另外还实现了IEnumerable泛型接口,实现此接口后就无需显式地迭代Animals属性
    /// //public interface IEnumerable<out T> : IEnumerable
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Farm<T> : IEnumerable<T>
        where T : Animal
    {
        private List<T> animals = new List<T>();
        /// <summary>
        /// 而是将公共属性Animals定义为泛型List类
        /// 该List类由类Farm的类型参数T确定,且被约束为Animal或者继承自Animal
        /// </summary>
        public List<T> Animals
        {
            get { return animals; }
        }

        /// <summary>
        /// 需要实现IEnumerable<T>泛型类的函数GetEnumerator()
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return animals.GetEnumerator();
        }

        /// <summary>
        /// 因为IEnumerable<T>泛型类继承自IEnumerable类
        /// 所以还需要实现IEnumerable.GetEnumerator()
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return animals.GetEnumerator();
        }

        //利用了抽象类Animal的方法MakeANoise()    因为T被约束为Animal，所以可以直接调用Animal的方法
        public void MakeNoises()
        {
            foreach (var item in animals)
            {
                item.MakeANoise();
            }
        }

        //利用了抽象类Animal的方法Feed()    因为T被约束为Animal，所以可以直接调用Animal的方法
        public void FeedTheAnimals()
        {
            foreach (var item in animals)
            {
                item.Feed();
            }
        }

        /// <summary>
        /// 提取集合中类型为Cow的所有项，包括继承自Cow的类
        /// </summary>
        /// <returns></returns>
        public Farm<Cow> GetCows()
        {
            Farm<Cow> cowFarm = new Farm<Cow>();
            foreach (var item in animals)
            {
                if (item is Cow)
                {
                    cowFarm.Animals.Add(item as Cow);
                }
            }
            return cowFarm;
        }
    }
}
