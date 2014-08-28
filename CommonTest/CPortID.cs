using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
namespace CommonTest
{
    /// <summary>
    /// 获取串口ID的类
    /// </summary>
    class CPortID
    {
        /// <summary>
        /// 获取串口ID的方法,ID按照从大到小的顺序排列
        /// </summary>
        /// <returns></returns>
        public static int[] GetPortID()
        {
            try
            {
                int temp = 0;
                string[] portname = SerialPort.GetPortNames();//获取串口名
                int[] comID = new int[portname.Length];
                for (int i = 0; i < portname.Length; i++)//获取串口ID
                {
                    comID[i] = Convert.ToInt32(portname[i].Substring(3, portname[i].Length - 3));
                }
                //冒泡排序算法对串口ID进行降序排列
                for (int i = 0; i < comID.Length - 1; i++)
                {
                    for (int j = 0; j < comID.Length - 1 - i; j++)
                    {
                        if (comID[j] < comID[j + 1])
                        {
                            temp = comID[j];
                            comID[j] = comID[j + 1];
                            comID[j + 1] = temp;
                        }
                    }
                }
                return comID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
