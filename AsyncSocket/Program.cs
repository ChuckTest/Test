using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
namespace AsyncSocket
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("192.168.1.39"), 1333);

            Server objServer = new Server(1000, 10);
            objServer.Init();
            objServer.Start(iep);
        }
    }
}
