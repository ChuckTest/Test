using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Ch11Ex05
{
    /// <summary>
    /// IComparer在一个单独的类中实现，可以比较任意两个对象
    /// </summary>
    class PersonComparerName : IComparer
    {
        public static IComparer Default = new PersonComparerName();

        public int Compare(object x, object y)
        {
            if (x is Person && y is Person)
            {
                return Comparer.Default.Compare(((Person)x).Name, ((Person)y).Name);
            }
            else
            {
                throw new ArgumentException("One or both objects to compare are not Person objects.");
            }
        }
    }
}
