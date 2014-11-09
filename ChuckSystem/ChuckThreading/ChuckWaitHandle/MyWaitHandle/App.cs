using System;
using System.Threading;

namespace MyWaitHandle
{
    class App
    {
        //ThreadPool.QueueUserWorkItem将方法排入队列以便执行，并指定包含该方法所用数据的对象。 此方法在有 线程池 线程变得可用时执行。
        static void Main()
        {
            DateTime dt = DateTime.Now;
            Console.WriteLine("主线程等待其他任务完成");
            //让两个任务在不同的线程中执行
            ThreadPool.QueueUserWorkItem(new WaitCallback(DoTask),waitHandles[0]);//第二个参数是方法使用的对象
            ThreadPool.QueueUserWorkItem(new WaitCallback(DoTask),waitHandles[1]);
            //调用WaitHandle的静态方法WaitAll()
            WaitHandle.WaitAll(waitHandles);//等待指定数组中的所有元素都收到信号。  返回值：如果 waitHandles 中的每个元素都收到信号，则返回 true；否则该方法永不返回。
            Console.WriteLine("其他任务完成，耗时{0}毫秒", (DateTime.Now - dt).TotalMilliseconds);//输出的时间是耗时最长的那个任务所花费的时间

            dt = DateTime.Now;
            Console.WriteLine();
            Console.WriteLine("主线程等待任意一个任务完成");
            ThreadPool.QueueUserWorkItem(new WaitCallback(DoTask), waitHandles[0]);
            ThreadPool.QueueUserWorkItem(new WaitCallback(DoTask), waitHandles[1]);
            int index = WaitHandle.WaitAny(waitHandles);//等待指定数组中的任一元素收到信号。  返回值：满足等待的对象的数组索引。
            Console.WriteLine("任务{0}完成，耗时{1}毫秒", index + 1, (DateTime.Now - dt).TotalMilliseconds);//输出的时间是耗时最短的那个任务所花费的时间

            Console.Read();

        }
        static Random r = new Random();

        static void DoTask(object state)
        {
            AutoResetEvent are = (AutoResetEvent)state;
            int time = 1000 * r.Next(2, 10);//返回2到10内的随机数  time是毫秒数
            Console.WriteLine("{0}秒执行任务",time/1000);
            Thread.Sleep(time);//休眠一段时间
            are.Set();  //are是AsyncResult的缩写
        }

        //AutoResetEvent继承自EventWaitHandle  AutoResetEvent是密封类
        //EventWaitHandle继承自WaitHandle      EventWaitHandle
        //WaitHandle继承自MarshalByRefObject抽象类和IDisposable接口    WaitHandle是抽象类
        static WaitHandle[] waitHandles = new WaitHandle[] {new AutoResetEvent(false),new AutoResetEvent(false) };
    }
}
