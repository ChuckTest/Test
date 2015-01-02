using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonTest.Chapter13.Ch13Ex03
{
    class Ch13Ex03
    {
        public static void Method()
        {
            Connection conn1 = new Connection();
            conn1.Name = "First Connection";
            Connection conn2 = new Connection();
            conn2.Name = "Second Connection";
            Display dis = new Display();
            conn1.MessageArrived += new MessageHandler(dis.DisplayMessage);
            conn2.MessageArrived += new MessageHandler(dis.DisplayMessage);
            conn1.Connect();
            conn2.Connect();
        }
    }
}
