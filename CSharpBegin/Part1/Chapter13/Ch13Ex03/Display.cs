using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch13Ex03
{
    class Display
    {
        public void DisplayMessage(Connection conn, MessageArrivedEventArgs e)
        {
            Console.WriteLine("Message Arrived from:{0}", conn.Name);
            Console.WriteLine("Message Text:{0}", e.Message);
        }
    }
}
