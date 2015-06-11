using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread = {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine();

            Action<object> action = (object obj) =>
            {
                Console.WriteLine("obj = {0}{3}Task = {1}{3}Thread = {2}{3}", obj.ToString(), Task.CurrentId, Thread.CurrentThread.ManagedThreadId, Environment.NewLine);
            };

            Task t1 = new Task(action, "t1 = new Task(Action<Object>, Object).Start()");

            Task t2 = Task.Factory.StartNew(action, "t2 = Task.Factory.StartNew(Action<Object>, Object)");
            t2.Wait();

            t1.Start();

            Console.WriteLine("t1 has been launched.");
            Console.WriteLine();

            t1.Wait();

            Task t3 = new Task(action, "t3 = new Task(Action<Object>, Object).RunSynchronously()");
            t3.RunSynchronously();

            t3.Wait();
            Console.ReadKey();
        }
    }
}
