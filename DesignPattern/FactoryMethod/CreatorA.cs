using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    /// <summary>
    /// 具体的Creator类 CreatorA
    /// </summary>
    class CreatorA : Creator
    {
        /// <summary>
        /// 负责创建某一个具体的子类 ChildA
        /// </summary>
        /// <returns></returns>
        internal override Parent Create()
        {
            ChildA childA = new ChildA();
            //将具体类的实例返回
            return childA;
        }
    }
}
