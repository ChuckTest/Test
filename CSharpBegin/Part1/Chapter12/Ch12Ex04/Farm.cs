using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Ch12Ex04
{
    class Farm<T> : IEnumerable<T>
        where T : Animal
    {
        private List<T> animals = new List<T>();
        public List<T> Animals
        {
            get { return animals; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return animals.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return animals.GetEnumerator();
        }

        public void MakeNoises()
        {
            foreach (var item in animals)
            {
                item.MakeANoise();
            }
        }

        public void FeedTheAnimals()
        {
            foreach (var item in animals)
            {
                item.Feed();
            }
        }

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
