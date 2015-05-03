using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Ch13Ex03
{
    /// <summary>
    /// 事件的委托包含了事件处理程序中常见的两个参数
    /// </summary>
    /// <param name="conn"></param>
    /// <param name="e"></param>
    public delegate void MessageHandler(Connection conn, MessageArrivedEventArgs e);
    public class Connection
    {
        public event MessageHandler MessageArrived;
        private Timer timer;
        public Connection()
        {
            timer = new Timer();
            timer.Interval = 500;
            timer.Elapsed += new ElapsedEventHandler(CheckForMessage);
            //public delegate void ElapsedEventHandler(object sender, ElapsedEventArgs e);
            //sender引发事件的对象的引用
            //ElapsedEventArgs由事件传送的参数
            //在这个事件中使用object类型参数的原因是，我们常常要为由不同的对象引发的几个相同事件使用同一个事件处理程序，但仍要指定哪个对象引发了事件
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private static Random random = new Random();
        private void CheckForMessage(object sender, EventArgs e)
        {
            Console.WriteLine("Checking for new messages.");
            if (random.Next(9) == 0)
            {
                if (MessageArrived != null)
                {
                    MessageArrived(this, new MessageArrivedEventArgs("Hello Mum!"));
                }
            }
        }

        public void Connect()
        {
            timer.Enabled = true;
        }

        public void Disconnect()
        {
            timer.Enabled = false;
        }
    }
}
