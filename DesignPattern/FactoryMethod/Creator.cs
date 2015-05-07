using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    /// <summary>
    /// 抽象类 但不意味是抽象工厂
    /// </summary>
    abstract class Creator
    {
        /// <summary>
        /// 需要有一个抽象方法Create，确保所有的子类都实现它
        /// </summary>
        /// <returns>返回类型需要是父类或者接口</returns>
        internal abstract Parent Create();
    }
}
