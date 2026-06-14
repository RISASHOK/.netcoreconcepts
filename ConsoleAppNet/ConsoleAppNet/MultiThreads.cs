using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleAppNet
{
    public class MultiThreads
    {
        public void MainThreadMethod()
        {
            ThreadStart threadStart = new ThreadStart(ChildThreadMethod);
            Thread childThread = new Thread(threadStart);
            childThread.Start();
            Console.WriteLine("thread is main thread");
        }
        public static void ChildThreadMethod()
        {
            Console.WriteLine("thread is child thread");

            Thread.Sleep(5000);

            Console.WriteLine("child thread is completed");
        }
    }
}
