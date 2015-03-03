using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch11Ex02
{
    class Animals : CollectionBase
    {
        public void Add(Animal newAnimal)
        {
            List.Add(newAnimal);
        }

        public void Remove(Animal oldAnimal)
        {
            List.Remove(oldAnimal);
        }

        public Animals()
        { }

        //索引符是一种特殊类型的属性，可以把它添加到一个类中，以提供类似于数组的访问
        public Animal this[int animalIndex]
        {
            get 
            {
                //List属性返回的是object对象，所以需要强制转换
                return (Animal)List[animalIndex];
            }
            set 
            { 
                List[animalIndex] = value; 
            }
        }

    }
}
