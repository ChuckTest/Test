﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch13Ex03
{
    class Program
    {
        static void Main(string[] args)
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
            Console.ReadKey();
        }
    }
}
