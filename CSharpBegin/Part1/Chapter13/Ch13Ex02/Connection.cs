using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Ch13Ex02
{
    //在定义事件之前，必须先定义一个委托，以用于该事件
    //这个委托指定了事件处理方法必须有的返回类型和参数
    public delegate void MessageHandler(string messageText);//此委托类型称为MessageHandler,是void函数的签名，有一个string参数
    public class Connection
    {
        //定义委托之后，就可以把事件本身定义为Connection的成员
        public event MessageHandler MessageArrived;//给事件命名，用event关键字和要使用的委托类型声明它

        private Timer timer;
        public Connection()
        {
            timer = new Timer();
            timer.Interval = 100;
            timer.Elapsed += new ElapsedEventHandler(CheckForMessage);
            //public event ElapsedEventHandler Elapsed;//Elapsed的定义，是一个事件
            //public delegate void ElapsedEventHandler(object sender, ElapsedEventArgs e);//ElapsedEventHandler是一个委托
        }

        private static Random random = new Random();
        private void CheckForMessage(object sender, ElapsedEventArgs e)//只要返回类型，还有参数 符合委托就可以了
        {
            Console.WriteLine("Checking For new message.");
            if (random.Next(9) == 0)
            {
                if (MessageArrived != null)//判断事件是否有订阅器
                {
                    //声明事件之后就可以引发它，方法是按照名称来调用它,就好像它是一个返回类型和参数是由委托指定的方法一样
                    MessageArrived("Hello Mum!");
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
