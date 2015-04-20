using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch12Ex03
{
    /// <summary>
    /// 静态类
    /// </summary>
    static class VectorDelegates
    {
        /// <summary>
        /// 比较大小
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        //对应于泛型委托public delegate int Comparison<in T>(T x, T y);//表示比较同一类型的两个对象的方法。
        public static int Compare(Vector x, Vector y)
        {
            if (x.R > y.R)
            {
                return 1;
            }
            else if (x.R < y.R)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 判断一个Vector是否处于右上角的象限
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        //对应于泛型委托public delegate bool Predicate<in T>(T obj);//表示定义一组条件并确定指定对象是否符合这些条件的方法。
        public static bool TopRightQuadrant(Vector target)
        {
            if (target.Theta >= 0.0 && target.Theta <= 90.0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
