using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch12Ex03
{
    class Vectors : List<Vector>
    {
        public Vectors()
        { }

        public Vectors(IEnumerable<Vector> initialItems)
        {
            foreach(var item in initialItems)
            {
                this.Add(item);
            }
        }

        public string Sum()
        {
            StringBuilder sb = new StringBuilder();
            Vector currentPoint = new Vector(0.0, 0.0);
            sb.Append("origin");
            foreach (var item in this)
            {
                sb.AppendFormat(" + {0}", item);
                currentPoint += item;
            }
            sb.AppendFormat(" = {0}", currentPoint);
            return sb.ToString();
        }
    }
}
