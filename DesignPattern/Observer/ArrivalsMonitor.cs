using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    /// <summary>
    /// an IObserver<T> implementation named ArrivalsMonitor, is a base class that displays baggage claim information.
    /// The information is displayed alphabetically, by the name of the originating city. 
    /// The methods of ArrivalsMonitor are marked as virtual (in C#), so they can all be overridden by a derived class.
    /// </summary>
    class ArrivalsMonitor : IObserver<BaggageInfo>
    {
        string name;

        internal string Name
        {
            get { return name; }
        }

        List<string> flightInfos = new List<string>();
        IDisposable cancellation;//The Subscribe method enables the class to save the IDisposable implementation returned by the call to Subscribe to a private variable. 
        string format = "{0,-20} {1,5}  {2, 3}";

        internal ArrivalsMonitor(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("The observer must be assigned a name.");
            }
            this.name = name;
        }

        //The ArrivalsMonitor class includes the Subscribe and Unsubscribe methods. 

        internal virtual void Subscribe(BaggageHandler provider)
        {
            Console.WriteLine(string.Format("{0}准备订阅通知", name));
            cancellation = provider.Subscribe(this);
            Console.WriteLine(string.Format("{0}订阅通知成功", name));
        }

        internal virtual void UnSubscribe()
        {
            Console.WriteLine(string.Format("{0}准备取消订阅", name));
            //The Unsubscribe method enables the class to unsubscribe from notifications by calling the provider's Dispose implementation.
            cancellation.Dispose();
            Console.WriteLine(string.Format("{0}取消订阅成功", name));
            flightInfos.Clear();
        }


        //ArrivalsMonitor also provides implementations of the OnNext, OnError, and OnCompleted methods. 
        public virtual void OnCompleted()
        {
            flightInfos.Clear();
        }

        public virtual void OnError(Exception e)
        {
            //不实现内容
        }

        //Only the OnNext implementation contains a significant amount of code. 

        public virtual void OnNext(BaggageInfo info)
        {
            //The method works with a private, sorted, generic List<T> object that maintains information about the airports of origin for arriving flights 
            //and the carousels on which their baggage is available.

            bool updated = false;//标记是否有新行李抵达或者是否有行李被卸货

            if (info.Carousel == 0)//行李已经卸货了
            {
                //If the BaggageHandler class reports that the flight's baggage has been unloaded, 
                //the OnNext method removes that flight from the list. Whenever a change is made, the list is sorted and displayed to the console.
                var flightsToRemove = new List<string>();
                string flightNo = string.Format("{0,5}", info.FlightNumber);
                foreach (var flightInfo in flightInfos)
                {
                    if (flightInfo.Substring(21, 5).Equals(flightNo))
                    {
                        flightsToRemove.Add(flightInfo);
                        updated = true;//行李被卸货
                    }
                }
                foreach (var flightInfo in flightsToRemove)
                {
                    flightInfos.Remove(flightInfo);
                }
                flightsToRemove.Clear();
            }
            else
            {
                // If the BaggageHandler class reports a new flight arrival, the OnNext method implementation adds information about that flight to the list.
                // Add flight if it does not exist in the collection. 
                string flightInfo = String.Format(format, info.From, info.FlightNumber, info.Carousel);//先把城市，航班编号，传送带编号，组成一个字符串
                if (flightInfos.Contains(flightInfo) == false)//判断是否重复的信息，如果重复就不处理
                {
                    flightInfos.Add(flightInfo);
                    updated = true;//新行李抵达
                }
            }
            if (updated)
            {
                flightInfos.Sort();
                Console.WriteLine("The left baggage info from {0}", this.name);
                foreach (var flightInfo in flightInfos)
                {
                    Console.WriteLine(flightInfo);
                }
                Console.WriteLine();
            }
        }
    }
}
