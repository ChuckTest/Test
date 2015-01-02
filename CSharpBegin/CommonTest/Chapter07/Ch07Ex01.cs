using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;//Debug.WriteLine();
namespace CommonTest.Chapter07
{
    class Ch07Ex01
    {
        public static void Method()
        {
            int[] testArray = { 4, 7, 4, 2, 7, 3, 7, 8, 3, 9, 1, 9 };//初始化一个测试用的整数数组
            int[] maxValIndices;//声明一个整数数组,用于存储Maxima函数的下标结果
            //调用函数
            int maxVal = Maxima(testArray,out maxValIndices);
            //输出返回结果
            Console.WriteLine("Maximum value {0} found at element indices.", maxVal);
            foreach (int index in maxValIndices)
            {
                Console.WriteLine(index);
            }
            Console.ReadKey();
        }

        /// <summary>
        /// 计算整数数组中的最大值
        /// </summary>
        /// <param name="integers">整数数组</param>
        /// <param name="indices">存储最大值的下标</param>
        /// <returns></returns>
        static int Maxima(int[] integers, out int[] indices)//最大数，极大值
        {
            Debug.WriteLine("Maximum value search started.");
            
            //开始搜索时，假定源数组中的第一个元素就是最大值,且数组中只有一个最大值
            indices = new int[1];
            int maxVal = integers[0];//将数组中的第一个元素赋予maxVal
            indices[0] = 0;//第一个元素的下标
            int count = 1;//存储搜索到的最大值的个数

            Debug.WriteLine(string.Format("Maximum value intialized to {0},at element index 0.", maxVal));//string.Format()比使用+连接运算符略高效些
            for (int i = 1; i < integers.Length; i++)//循环遍历整数数组，但忽略第一个元素，因为已经处理过
            {
                Debug.WriteLine(string.Format("Now looking at element at index {0}.", i));
                if (integers[i] > maxVal)//每个值都和maxVal比较
                {
                    maxVal = integers[i];//修改最大值
                    count = 1;
                    indices = new int[1];//修改下标数组
                    indices[0] = i;
                    Debug.WriteLine(string.Format("New maximum found. New value is {0},at element index {1}.", maxVal, i));
                }
                else
                {
                    if (integers[i] == maxVal)//找到和最大值相同的数据，记录index
                    {
                        count++;
                        int[] oldIndices = indices;//先备份旧的下标数组
                        indices = new int[count];//重建不同长度的数组来实现返回一个刚好能容纳搜索到的下标的数组

                        //CopyTo()函数：把oldIndices中的值复制到新的indices数组中，此函数只提取一个目标数组和一个用于复制第一个元素的下标
                        oldIndices.CopyTo(indices, 0);//把旧数组中的值复制到新的数组

                        indices[count - 1] = i;
                        Debug.WriteLine(string.Format("Duplicate maximum {0} found, with {1} occurrences", maxVal, count));
                    }
                }
            }
            Trace.WriteLine(string.Format("Maximum value {0} found,with {1} occurrences.", maxVal, count));//输出窗口中的Release模式下
            Debug.WriteLine("Maximum value search completed.");
            return maxVal;
        }
    }
}
