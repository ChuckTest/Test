using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//http://baike.baidu.com/view/160596.htm?fr=aladdin  关于DAO的解释[data access object]
namespace ChuckDAO
{
    //做成dll的时候,必须使用静态方法
    /// <summary>
    /// 转换类
    /// </summary>
    public class ConvertHelper
    {
        /// <summary>
        /// BCD转十进制
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static int BcdToDec(byte hex)
        {
            return Convert.ToByte(ToHexString(hex));
        }

        /// <summary>
        /// 十进制转十六进制
        /// </summary>
        /// <param name="dec"></param>
        /// <returns></returns>
        public static byte[] DecToHexByteArray(Int64 dec)
        {
            string decStr = Convert.ToString(dec, 16);
            byte[] hexArray = null;
            if (decStr.Length % 2 == 0)
                hexArray = HexStringToByteArray(decStr);
            else
                hexArray = HexStringToByteArray("0" + decStr);
            return hexArray;
        }

        /// <summary>
        /// 十进制转十六进制
        /// </summary>
        /// <param name="dec"></param>
        /// <returns></returns>
        public static byte[] DecToHexByteArray(Int64 dec, int targetByteArrayLength)
        {
            string decStr = Convert.ToString(dec, 16);
            while (decStr.Length < targetByteArrayLength * 2)
            {
                decStr = "0" + decStr;
            }

            return HexStringToByteArray(decStr);
        }

        /// <summary>
        /// 字符串转16进制字节数组
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static byte[] BinaryStrToHexByte(string binaryString)
        {
            binaryString = binaryString.Replace(" ", "");
            if ((binaryString.Length % 8) != 0)
                binaryString += "0";
            byte[] returnBytes = new byte[binaryString.Length / 8];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(binaryString.Substring(i * 8, 8), 2);
            return returnBytes;
        }

        /// <summary>
        /// 字节转化为16进制字符
        /// </summary>
        /// <param name="b">字节：0xFF</param>
        /// <returns>16进制字符："FF"</returns>
        public static string ToHexString(byte b)
        {
            string hexString = Convert.ToString(b, 16);
            while (hexString.Length < 2)
                hexString = "0" + hexString;
            return hexString.ToUpper();
        }

        /// <summary>
        /// 字节数组转成字节字符串
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static string HexArrayToString(byte[] commandArray)
        {
            if (commandArray == null) return null;
            string commandStr = string.Empty;

            foreach (byte command in commandArray)
            {
                commandStr += ToHexString(command);
            }

            return commandStr;
        }


        /// <summary>
        /// 得到测点号
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int StringToInt(string str)
        {
            string returnStr = string.Empty;
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsNumber(str, i))
                {
                    returnStr += str.Substring(i, 1);
                }
            }
            if (string.Equals(returnStr, string.Empty)) return 0;
            return Convert.ToInt32(returnStr);
        }

        /// <summary>
        /// 10进制数字（255以下）转化为16进制字符
        /// </summary>
        /// <param name="num">10进制数字：255</param>
        /// <returns>16进制字符："FF"</returns>
        public static string ToHexString(int num)
        {
            string hexString = Convert.ToString(num, 16);
            while (hexString.Length < 2)
                hexString = "0" + hexString;
            return hexString.ToUpper();
        }

        /// <summary>
        /// 16进制字符转化为字节
        /// </summary>
        /// <param name="s">16进制字符："FF"</param>
        /// <returns>字节 0xFF</returns>
        public static byte HexStringToByte(string s)
        {
            return Convert.ToByte(s, 16);
        }

        /// <summary>
        /// 10进制数字（255以下）转化为16进制字节
        /// </summary>
        /// <param name="num">10进制数字：255</param>
        /// <returns>字节 0xFF</returns>
        public static byte ToByte(int num)
        {
            return Convert.ToByte(Convert.ToString(num, 16), 16);
        }

        /// <summary>
        /// 10进制字符转化为16进制Ascii码字节
        /// </summary>
        /// <param name="s">10进制字符："0"</param>
        /// <returns>16进制Ascii码字节：0x30</returns>
        public static byte ToByte(string s)
        {
            return new ASCIIEncoding().GetBytes(s)[0];
        }

        /// <summary>
        /// 10进制字符串转换成16进制Ascii码字节数组
        /// </summary>
        /// <param name="s">10进制字符串："255"</param>
        /// <returns>16进制Ascii码字节数组：0x32 0x35 0x35</returns>
        public static byte[] StringToByteArray(string s)
        {
            var buffer = new byte[s.Length];
            for (var i = 0; i < s.Length; i++)
            {
                buffer[i] = new ASCIIEncoding().GetBytes(s.Substring(i, 1))[0];
            }
            return buffer;
        }

        /// <summary>
        /// 16进制字符串转换成字节数组
        /// </summary>
        /// <param name="s">16进制字符串："323535"</param>
        /// <returns>字节数组：0x32 0x35 0x35</returns>
        public static byte[] HexStringToByteArray(string s)
        {
            var buffer = new byte[s.Length / 2];
            for (var i = 0; i < s.Length; i += 2)
            {
                buffer[i / 2] = Convert.ToByte(s.Substring(i, 2), 16);
            }
            return buffer;
        }

        /// <summary>
        /// 字节数组转换成16进制字符串
        /// </summary>
        /// <param name="data">字节数组</param>
        /// <returns>16进制字符串</returns>
        public static string ByteArrayToHexString(byte[] data)
        {
            var sb = new StringBuilder(data.Length * 3);
            foreach (var b in data)
            {
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
            }
            return sb.ToString().Trim().ToUpper();
        }

        /// <summary>
        /// ASCII转16进制
        /// </summary>
        /// <param name="ascii">ASCII</param>
        /// <returns>16进制</returns>
        public static string AsciiToHex(string ascii)
        {
            var cs = ascii.ToCharArray();
            var sb = new StringBuilder();
            foreach (var t in cs)
            {
                var hex = ((int)t).ToString("X");
                sb.AppendFormat("{0} ", hex);
            }
            return sb.ToString().TrimEnd(' ');
        }

        /// <summary>
        /// 16进制转ASCII
        /// </summary>
        /// <param name="hex">16进制</param>
        /// <returns>ASCII</returns>
        public static string HexToAscii(string hex)
        {
            if (hex.Length % 2 == 0)
            {
                var result = string.Empty;
                var length = hex.Length / 2;

                for (var i = 0; i < length; i++)
                {
                    var iValue = Convert.ToInt32(hex.Substring(i * 2, 2), 16);
                    var bs = BitConverter.GetBytes(iValue);
                    var sValue = Encoding.ASCII.GetString(bs, 0, 1);
                    result += char.Parse(sValue).ToString();
                }
                return result.PadLeft(length, '0');
            }
            return string.Empty;
        }

        /// <summary>
        /// 十进制数组转化成ASCII字符串
        /// </summary>
        /// <param name="dex"></param>
        /// <returns></returns>
        public static string DecToHexAscii(int[] decArray)
        {
            string hexString = string.Empty;

            foreach (int dec in decArray)
            {
                hexString += HexToAscii(ToHexString(dec));
            }

            return hexString;
        }

        /// <summary>
        /// 十进制转化成ASCII字符
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static string DecByteToHexAscii(int dec)
        {
            return HexToAscii(ToHexString(dec));
        }

        /// <summary>
        /// 十六进制转ASCII
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static string HexByteToAscii(byte hex)
        {
            return HexToAscii(ToHexString(hex));
        }

        /// <summary>
        /// 十六进制字节转二进制字符
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static string HexToBinString(byte hex)
        {
            string binString = Convert.ToString(Convert.ToInt32(ToHexString(hex), 16), 2);
            while (binString.Length < 8)
                binString = '0' + binString;
            return binString;
        }

        /// <summary>
        /// 十六进制转二进制字符串
        /// </summary>（new byte[]{0xde,0xdf} -5f de --〉101 1111-5f 1101 1110－de　）
        /// <param name="hexArray"></param>
        /// <returns></returns>
        public static string HexArrayToBinString(byte[] hexArray)
        {
            string binStr = string.Empty;
            for (int i = 0; i < hexArray.Length; i++)
            {
                binStr = HexToBinString(hexArray[i]) + binStr;
            }

            return binStr;
        }

        public static double ComputeStatic(byte datacache1, byte datacach2)
        {
            Int16 Compare = (Int16)(datacache1 << 8 | datacach2);
            return Compare / 1.0;
        }

        public static double ComputeSine(byte datacache1, byte datacach2)
        {
            int Compare = (datacache1 << 8 | datacach2);
            return Compare / 1.0;
        }
    }
}
