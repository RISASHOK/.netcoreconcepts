using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppNet
{
    public class ThreadPrioritys
    {

        public void MainThreadMethod()
        {
            ThreadClass thread = new ThreadClass();

            Thread childThread1 = new Thread(new ThreadStart(thread.ThreadMethod));
            Thread childThread2 = new Thread(new ThreadStart(thread.ThreadMethod));
            Thread childThread3 = new Thread(new ThreadStart(thread.ThreadMethod));

            childThread1.Name = "Player1";
            childThread2.Name = "Player2";
            childThread3.Name = "Player3";

            childThread1.Priority = ThreadPriority.Highest;
            childThread2.Priority = ThreadPriority.Lowest;
            childThread3.Priority = ThreadPriority.Normal;

            childThread1.Start();
            childThread2.Start();
            childThread3.Start();
            Console.WriteLine("thread is main thread");
        }

        //public void ChildThreadMethod()
        //{
        //    Thread thread = Thread.CurrentThread;
        //    Console.WriteLine("thread is child thread with priority {0}", thread.Priority);
        //}
    }
    public class ThreadClass()
    {
        public void ThreadMethod()
        {
            Thread thread = Thread.CurrentThread;
            Console.WriteLine("thread is child thread with name {0} running", thread.Name);
        }
    }
}
