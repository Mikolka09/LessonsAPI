using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LessonsAPI_4
{
    class Program
    {
        public static int counter = 0;

        static void Main(string[] args)
        {

            Counter counter = new Counter();
            Thread[] threads = new Thread[4];
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(counter.Increment);
                threads[i].Start();
            }
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Join();
            }

            Console.WriteLine(counter.count);



            Console.ReadLine();
        }
        Mutex m1 = Mutex.OpenExisting("M_M");


    }

    class Counter
    {
        public int count = 0;
        //object lck = new object();
        Mutex m = new Mutex(false, "M_M"); //для запуска одного потока
        Semaphore s = new Semaphore(2, 2, "M_S");//для запуска одновременно нескольких потоков
        AutoResetEvent e = new AutoResetEvent(true);
        ManualResetEvent man = new ManualResetEvent(true);
        public void Increment(object obj)
        {
            for (int i = 0; i < 10000; i++)
            {
                //Interlocked.Increment(ref count);
                //while (!Monitor.TryEnter(lck))
                //{

                //}

                //lock(lck)
                //{
                //    count++;
                //}

                //Monitor.Enter(lck);
                //try
                //{
                //    count++;
                //}
                //finally
                //{
                //    Monitor.Exit(lck);
                //}
                //m.WaitOne();
                //count++;
                //m.ReleaseMutex();
                //s.WaitOne();
                //count++;
                //s.Release();
                //e.WaitOne();
                //count++;
                //e.Set();
                man.WaitOne();
                man.Reset();
                count++;
                man.Set();
            }
        }
    }

}
