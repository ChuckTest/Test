using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparingPatterns
{
    public delegate void ReadCompletedEventHandler();
    abstract class EAP
    {
        public abstract void ReadAsync(byte[] buffer, int offset, int count);
        public event ReadCompletedEventHandler ReadCompleted;//ReadCompletedEventHandler
    }
}
