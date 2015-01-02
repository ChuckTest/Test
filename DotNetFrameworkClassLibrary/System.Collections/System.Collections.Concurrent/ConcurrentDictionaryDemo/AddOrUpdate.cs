using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace ConcurrentDictionaryDemo
{
    /// <summary>
    /// ConcurrentDictionary<TKey, TValue>.AddOrUpdate()代码示例
    /// </summary>
    class AddOrUpdate
    {
        // Demonstrates:   使用到三个方法
        //      ConcurrentDictionary<TKey, TValue>.AddOrUpdate()
        //      ConcurrentDictionary<TKey, TValue>.GetOrAdd()
        //      ConcurrentDictionary<TKey, TValue>[]
        internal static void Test()
        {
            // Construct a ConcurrentDictionary
            ConcurrentDictionary<int, int> cd = new ConcurrentDictionary<int, int>();

            // Bombard the ConcurrentDictionary with 10000 competing AddOrUpdates
            //给cd加key为1的键值对，然后更新key为1的value；最后更新为10000
            Parallel.For(0, 10000, i => {
                // Initial call will set cd[1] = 1.  
                // Ensuing calls will set cd[1] = cd[1] + 1
                cd.AddOrUpdate(1, 1, (key, oldValue) => oldValue + 1);
            });

            Console.WriteLine("After 10000 AddOrUpdates, cd[1] = {0} (should be 10000)", cd[1]);

            // Should return 100, as key 2 is not yet in the dictionary
            //得到或添加键值
            //如果key为2存在，就返回value；否则添加(2,100)并返回新的value
            int value = cd.GetOrAdd(2, (key) => 100);
            Console.WriteLine("After initial GetOrAdd, cd[2] = {0} (should be 100)", value);

            // Should return 100, as key 2 is already set to that value
            //如果key为2存在，就返回value；否则添加(2,10000)并返回新的value
            value = cd.GetOrAdd(2, 10000);
            Console.WriteLine("After second GetOrAdd, cd[2] = {0} (should be 100)", value);
        }
    }
}
