using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparingPatterns
{
    abstract class TAP
    {
        public abstract Task<int> ReadAstnc(byte[] buffer, int offset, int count);
    }
}
