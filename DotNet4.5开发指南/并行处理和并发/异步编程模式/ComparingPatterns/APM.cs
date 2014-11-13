using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparingPatterns
{
    abstract class APM
    {
        //public delegate void AsyncCallback(IAsyncResult ar);    //AsyncCallback是委托
        public abstract IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callBack, object state);
        public abstract int EndRead(IAsyncResult asyncResult);
    }
}
