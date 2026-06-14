using System;

namespace ConsoleAppNet
{
    class Program
    {
        public static void Main(string[] args)
        {
            Thread th = Thread.CurrentThread;
            th.Name = "Thread in Main Program";

            Console.WriteLine("thread is {0}", th.Name);

            MultiThreads thread1 = new MultiThreads();
            thread1.MainThreadMethod();

            ThreadPrioritys threadPrioritys = new ThreadPrioritys();
            threadPrioritys.MainThreadMethod();

            Console.ReadKey();
        }

        //public void ChildThreadMethod()
        //{
        //    Console.WriteLine("thread is child thread");

        //}
    }
}