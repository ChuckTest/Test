using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonTest.Chapter13
{
    /// <summary>
    /// 订阅事件的类
    /// </summary>
    public class Display
    {
        /// <summary>
        /// 此方法匹配于委托类型方法的签名，所以它可以响应MessageArrived事件
        /// 如果类不是生成该事件的类，则其处理事件程序必须是public的
        /// </summary>
        /// <param name="message"></param>
        public void DisplayMessage(string message)
        {
            Console.WriteLine("Messsage Arrived :{0}", message);
        }
    }
}
