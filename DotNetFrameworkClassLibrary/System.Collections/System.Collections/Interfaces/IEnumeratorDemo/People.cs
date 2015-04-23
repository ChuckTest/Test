using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace IEnumeratorDemo
{
    //IEnumerable负责使用foreach循环
    class People : IEnumerable
    {
        private Person[] personArray;
        public People(Person[] array)
        {
            personArray = new Person[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                personArray[i] = array[i];
            }
        }

        //foreach循环的步骤
        //1.调用集合的GetEnumerator方法，此方法返回一个IEnumerator接口对象
        //2.调用IEnumerator接口对象的MoveNext方法
        //3.如果MoveNext返回值为true，就取IEnumerator接口对象的Current对象的引用，用于foreach循环
        //4.重复第2和第3步，直到MoveNext返回false的时候停止循环
        public IEnumerator GetEnumerator()
        {
            return new PeopleEnum(personArray);
        }
    }
}
