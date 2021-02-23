using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Reflection;
using System.IO;


namespace LessonsAPI_2
{
    class Program
    {
        public static void Sum(object state)
        {
            int sum = 0;
            Random r = new Random();
            for (int i = 0; i < 100; i++)
            {
                sum += r.Next() % 5 + 1;
                Thread.Sleep(20);
            }
            Console.WriteLine("Sum = {0}", sum);
        }

        public static void Mult(object state)
        {
            int sum = 1;
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                sum *= r.Next() % 5 + 1;
                Thread.Sleep(10);
            }
            Console.WriteLine("Mult = {0}", sum);
        }

        public static void Diff(object state)
        {
            int sum = 0;
            Random r = new Random();
            for (int i = 0; i < 100; i++)
            {
                sum -= r.Next() % 8 + 1;
                Thread.Sleep(10);
            }
            Console.WriteLine("Diff = {0}", sum);
        }

        static void Main(string[] args)
        {
            ThreadPool.SetMinThreads(3, 6);
            ThreadPool.QueueUserWorkItem(Sum);
            ThreadPool.QueueUserWorkItem(Mult);
            ThreadPool.QueueUserWorkItem(Diff);
            //ThreadPool.GetMaxThreads(out var a, out var b);
            //Console.WriteLine("A = " + a);
            //Console.WriteLine("B = " + b);
            //Timer t = new Timer(Sum);
            //t.Change(2000, Timeout.Infinite);
            //t.Change(0, 1500);

            Console.ReadKey();
        }
    }
}
