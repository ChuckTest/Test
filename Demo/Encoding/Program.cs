using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace ConsoleApplicationEncoding
{
    [TestFixture]
    public class EncodingTest
    {

        [Test]
        public void Test()
        {
            List<string> list = new List<string> {"hello", "你好", "hello你好"};

            foreach (var item in list)
            {
                Output(item);
            }
        }

        private void Output(string input)
        {
            OutputLengthOfByteArray(input, Encoding.ASCII);
            OutputLengthOfByteArray(input, Encoding.Unicode);
            OutputLengthOfByteArray(input, Encoding.UTF32);
            OutputLengthOfByteArray(input, Encoding.UTF8);
            OutputLengthOfByteArray(input, Encoding.UTF7);
            Console.WriteLine();
        }

        public void OutputLengthOfByteArray(string input, Encoding encoding)
        {
            var array = encoding.GetBytes(input);
            Console.WriteLine($"Length of byte array for {input} in {encoding} is {array.Length}");
        }
    }
}
