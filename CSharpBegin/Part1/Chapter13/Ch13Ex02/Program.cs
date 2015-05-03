using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch13Ex02
{
    class Program
    {
        static void Main(string[] args)
        {
            Connection conn = new Connection();
            Display dis = new Display();
            //public delegate void MessageHandler(string messageText);
            //string参数可以把Connection对象conn接收到的即时消息发送给Display的对象dis
            conn.MessageArrived += new MessageHandler(dis.DisplayMessage);
            conn.Connect();

            Console.ReadKey();
        }
    }
}
