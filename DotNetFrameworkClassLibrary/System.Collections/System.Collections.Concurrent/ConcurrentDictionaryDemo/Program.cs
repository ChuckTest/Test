using System;
using System.Collections.Concurrent;

namespace ConcurrentDictionaryDemo
{
    /// <summary>
    /// 此示例仅仅使用了初始化的时候的初始元素个数
    /// </summary>
    class Program
    {
        // Demonstrates: 示例
        //      public ConcurrentDictionary(int concurrencyLevel,int capacity)  //构造函数
        //      参数说明
        //      concurrencyLevel  //将要并发更新ConcurrentDictionary<TKey, TValue>的预估线程的数量
        //      The estimated number of threads that will update the ConcurrentDictionary<TKey, TValue> concurrently.
        //      capacity  //ConcurrentDictionary<TKey, TValue>所能包含的初始元素个数
        //      The initial number of elements that the ConcurrentDictionary<TKey, TValue> can contain.
        //
        //      ConcurrentDictionary<TKey, TValue>[TKey]
        static void Main()
        {
            // We know how many items we want to insert into the ConcurrentDictionary.
            // 已经知道想要插多少元素到ConcurrentDictionary
            // So set the initial capacity to some prime number above that, to ensure that
            // the ConcurrentDictionary does not need to be resized while initializing it.
            // 设置初始的允许的元素个数大于已经要插入的元素个数，确保ConcurrentDictionary在初始化的时候，不需要调整大小
            int NUMITEMS = 64;
            int initialCapacity = 101;

            //concurrency并发  theoretical理论上的
            // The higher the concurrencyLevel, the higher the theoretical number of operations
            // that could be performed concurrently on the ConcurrentDictionary.  However, global
            // operations like resizing the dictionary take longer as the concurrencyLevel rises. 
            // For the purposes of this example, we'll compromise at numCores * 2.
            //越高的并发等级，理论上就会有越高的处理次数
            int numProcs = Environment.ProcessorCount;
            int concurrencyLevel = numProcs * 2;

            // Construct the dictionary with the desired concurrencyLevel and initialCapacity
            ConcurrentDictionary<int, int> cd = new ConcurrentDictionary<int, int>(concurrencyLevel, initialCapacity);

            // Initialize the dictionary    初始化并发字典  数量为64，小于初始化提供的基本参数101
            for (int i = 0; i < NUMITEMS; i++)
            {
                cd[i] = i * i;
            }

            Console.WriteLine("The square of 23 is {0} (should be {1})", cd[23], 23 * 23);

            Console.ReadKey();
        }
    }
}
