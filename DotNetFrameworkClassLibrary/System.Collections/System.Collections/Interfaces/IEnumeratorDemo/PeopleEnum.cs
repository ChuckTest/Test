using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace IEnumeratorDemo
{
    class PeopleEnum : IEnumerator
    {
        public Person[] people;

        int position = -1;

        public PeopleEnum(Person[] list)
        {
            people = list;
        }

        #region IEnumerator接口成员
        public object Current
        {
            get
            {
                try
                {
                    return people[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public bool MoveNext()
        {
            if (position < people.Length - 1)
            {
                position++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            position = -1;
        }
        #endregion
    }
}
