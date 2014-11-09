using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    class Program
    {

        static void Main(string[] args)
        {
            //接口仅仅能访问方法
            IWork p = new Employee() { Name = "巫妖王" };
            p.Work();

            //仅仅能访问Age和Name
            Person q = new Employee() { Name = "巫妖王" };
            Console.WriteLine(q.Age);
            Console.WriteLine(q.Name);

            Console.Read();
        }
    }
}
