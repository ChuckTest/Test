using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch11Ex05
{
    /// <summary>
    /// IComparable在要比较的对象的类中实现可以比较改对象和另一个对象
    /// </summary>
    class Person : IComparable
    {
        public string Name;
        public int Age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public int CompareTo(object obj)
        {
            if (obj is Person)
            {
                Person otherPerson = obj as Person;
                return this.Age - otherPerson.Age;
            }
            else
            {
                throw new ArgumentException("Object to compare to is not a Person Object");
            }
        }
    }
}
