using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
namespace AsyncSocket
{
    /// <summary>
    /// 微软没有提供这个类，所以随便写一个，只要包含一个Socket变量，就可以实现简单的功能
    /// </summary>
    class AsyncUserToken
    {
        public Socket Socket;
    }
}
