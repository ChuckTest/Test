using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory
{
    /// <summary>
    /// 简单工厂类
    /// </summary>
    class SimpleFactory
    {
        /// <summary>
        /// 步骤1 简单工厂有一个静态方法，通过接收客户端的参数来决定创建哪一个类型对象
        /// </summary>
        /// <param name="child"></param>
        /// <returns>步骤3 不确定简单工厂返回的对象是哪一种具体的类型，所以使用父类作为返回类型</returns>
        internal static Parent Create(ChildType child)
        {
            Parent parent = null;
            try
            {
                //步骤2  所有简单工厂能创建的对象,有同一个父类或接口
                //在此示例，ChildA,ChildB,ChildC拥有共同的父类Parent
                if (child == ChildType.A)
                {
                    return new ChildA();
                }
                else if (child == ChildType.B)
                {
                    return new ChildB();
                }
                else if (child == ChildType.C)
                {
                    return new ChildC();
                }
                else
                {
                    throw new Exception("不识别的Child类型");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return parent;
        }
    }
}
