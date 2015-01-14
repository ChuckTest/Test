using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Program
    {
        /// <summary>
        /// http://msdn.microsoft.com/en-us/library/ee850490(v=vs.110).aspx  初始的讲解
        /// http://msdn.microsoft.com/en-us/library/ee817669.aspx  探索示例，有图例
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            BaggageHandler provider = new BaggageHandler();
            ArrivalsMonitor observer1 = new ArrivalsMonitor("BaggageClaimMonitor1");
            ArrivalsMonitor observer2 = new ArrivalsMonitor("SecurityExit");

            provider.BaggageStatus(712, "Detroit", 3);
            observer1.Subscribe(provider);//订阅之后，provider会向observer1推送所有的消息
            provider.BaggageStatus(712, "Kalamazoo", 3);//添加新的行李后，会遍历所有的观察者，然后推送消息 此时只有一个
            provider.BaggageStatus(400, "New York-Kennedy", 1);//添加新的行李后，会遍历所有的观察者，然后推送消息 此时只有一个

            //此信息为重复信息，提供者不会进行判断，最后导致提供者有2个相同的消息推送给观察者
            //但是提供者推送的时候，观察者会自行区分重复的信息
            provider.BaggageStatus(712, "Detroit", 3);//添加新的行李后，会遍历所有的观察者，然后推送消息 此时只有一个

            observer2.Subscribe(provider);//订阅之后，provider会向observer2推送所有的消息
            provider.BaggageStatus(511, "San Francisco", 2);//添加新的行李后，会遍历所有的观察者，然后推送消息 此时有两个观察者
            provider.BaggageStatus(712);//卸货航班编号712的行李
            observer2.UnSubscribe();//取消订阅
            provider.BaggageStatus(400);//卸货航班编号400的行李
            provider.LastBaggageClaimed();

            Console.ReadKey();
        }
    }
}
