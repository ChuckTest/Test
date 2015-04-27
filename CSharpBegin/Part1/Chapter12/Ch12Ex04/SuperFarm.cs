using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch12Ex04
{
    /// <summary>
    /// 从泛型类继承，不能解除父类的约束
    /// 不能是超集class，也不能是其他的类型，比如struct
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class SuperFarm<T> : Farm<T>
        where T : SuperCow//这里的约束至少要与父类相同，或者是父类的子集
    {
    }
}
