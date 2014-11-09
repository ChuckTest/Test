using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    class Employee : Person, IWork
    {
        /// <summary>
        /// 此方法必须是public的，因为需要实现IWork接口的成员
        /// </summary>
        public void Work()
        {
            Console.WriteLine("{0} is working.", Name);
        }
    }
}
