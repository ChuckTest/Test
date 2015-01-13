using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    /// <summary>
    /// The following example uses the observer design pattern to implement an airport baggage claim information system. 
    /// A BaggageInfo class provides information about arriving flights and the carousels where baggage from each flight is available for pickup. 
    /// It is shown in the following example.
    /// </summary>
    class BaggageInfo
    {
        int flightNo;
        string origin;
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
            carousel = location;
        }

        /// <summary>
        /// arriving flights
        /// </summary>
        internal int FlightNumber
        {
            get { return flightNo; }
        }

        internal string From
        {
            get { return origin; }
        }

        /// <summary>
        /// 行李所用转盘
        /// </summary>
        internal int Carousel
        {
            get { return location; }
        }
    }
}
