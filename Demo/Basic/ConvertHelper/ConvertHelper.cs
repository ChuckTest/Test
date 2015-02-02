using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertHelperDemo
{
    public class ConvertHelper
    {
        /// <summary>
        /// 十六进制字符串转换成字节数组  字符串长度必须为偶数
        /// 举例   输入abcdef0103dac3  不区分大小写
        /// 得到的字节数组  171,205,239,  1,  3,218,195,
        /// 171对应ab，205对应cd，239对应ef，01对应1,03对应3，da对应218，c3对应195
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static byte[] HexStringToByteArray(string s)
        {
            try
            {
                Debug.WriteLine(string.Format("字符串{0}的长度为{1}", s, s.Length));

                if (s.Length % 2 == 1)
                {
                    throw new Exception(string.Format("HexStringToByteArray传入的字符串长度为奇数{0}，不符合要求", s.Length));
                }

                byte[] buffer = new byte[s.Length / 2];
                string tmp = string.Empty;
                for (int i = 0; i < buffer.Length; i++)
                {
                    //从字符串中逐次截取2个长度的子字符串,
                    tmp = s.Substring(i * 2, 2);
                    buffer[i] = Convert.ToByte(tmp, 16);//第二个参数16表示tmp子字符串中是十六进制
                }
                return buffer;
            }
            catch
            {
                throw;
            }
        }
    }
}
