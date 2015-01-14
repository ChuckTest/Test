using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    /// <summary>
    /// IObservable<T>   provider实现的接口
    /// IObserver<T>     observer实现的接口
    /// 这两个接口中的T的类型
    /// 
    /// The following example uses the observer design pattern to implement an airport baggage claim information system. 
    /// A BaggageInfo class provides information about arriving flights and the carousels where baggage from each flight is available for pickup. 
    /// It is shown in the following example.
    /// </summary>
    class BaggageInfo
    {
        /// <summary>
        /// 航班
        /// </summary>
        int flightNo;
        /// <summary>
        /// 来源城市
        /// </summary>
        string origin;
        /// <summary>
        /// 旋转行李传送带的编号  如果为0，表示行李已经被取走
        /// </summary>
        int location;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="flight"></param>
        /// <param name="from"></param>
        /// <param name="carousel"></param>
        internal BaggageInfo(int flight,string from,int carousel)
        {
            flightNo = flight;
            origin = from;
            location = carousel;
        }

        /// <summary>
        /// arriving flights
        /// </summary>
        internal int FlightNumber
        {
            get { return flightNo; }
        }

        /// <summary>
        /// 飞机起航的城市
        /// </summary>
        internal string From
        {
            get { return origin; }
        }

        /// <summary>
        /// 行李所用转盘  如果为0，表示行李已经被取走
        /// A baggage carousel is a device, generally at an airport,
        /// that delivers checked luggage to the passengers at the baggage claim area at their final destination.
        /// </summary>
        internal int Carousel
        {
            get { return location; }
        }
    }
}
