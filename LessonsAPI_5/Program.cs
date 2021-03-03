using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace LessonsAPI_5
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();


            //Task task = new Task(() => Console.WriteLine("Hello"));
            //task.Start();
            ////task.Wait(); //останавливает основной поток пока не выполнится фоновый
            //Task<int> task2 = new Task<int>(() => 2 * 8);
            //task2.Start();
            //Console.WriteLine(task2.Result);
            //Task task3 = Task.Run(() => 2 + 8).
            //    ContinueWith((Task<int> t) => (double)t.Result * t.Result).
            //    ContinueWith((Task<double> t) => t.Result / 3).
            //    ContinueWith((Task<double> t) => Console.WriteLine(t.Result));

            //int sum = 0;
            //int i2 = 0;
            //Task task = Task.Run(()=>{

            //    for (int i = 0; i < 10000; i++)
            //    {
            //        sum+=i;
            //        if(cancellationTokenSource.Token.IsCancellationRequested) return;
            //    }
            //});
            //Console.ReadKey();
            //cancellationTokenSource.Cancel();
            //Console.WriteLine(sum);

            //Parallel.Invoke(() => Console.WriteLine("H"),
            //                () => Console.WriteLine("E"),
            //                () => Console.WriteLine("L"),
            //                () => Console.WriteLine("L"),
            //                () => Console.WriteLine("O"));
            //int[] arr = new int[10];
            //ParallelLoopResult r = Parallel.For(1, 10, (int i) => arr[i] = i * 2);

            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.WriteLine(arr[i]);
            //}
            //Parallel.ForEach(new List<double> { 0.1, 0.2, 0.3, 0.4 }, (double i) => Console.WriteLine(i * 2));
            //Parallel.ForEach(new List<double> { 0.1, 0.2, 0.3, 0.4 }, (double i, ParallelLoopState state) =>
            //                    { if (i == 0.3) state.Break(); Console.WriteLine(i * 2); });

            //List<double> lst = new List<double>() { 0.1, 0.2, 0.3, 0.4 };
            //var _lst1 = from l in lst.AsParallel().AsOrdered().WithCancellation(cancellationTokenSource.Token)
            //            select l * 2;
            //List<double> lst1 = _lst1.ToList();

            //List<double> lst2 = lst.Select((double l) => l * 2).ToList();
            //List<double> lst3 = lst.AsParallel().WithCancellation(cancellationTokenSource.Token).Select((double l) => l * 2).ToList();
            //foreach (var item in lst3)
            //{
            //    Console.WriteLine(item);
            //}

            Task t = DoSomething(2,3);
            t.Wait();


            Console.ReadKey();
        }

        public static async Task DoSomething(int i1, int i2)
        {
            Console.WriteLine("Hello");
            await Task.Run(() => Console.WriteLine( i1 + i2));
            await Task.Run(() => Console.WriteLine( i1 * i2));
            await DoSomething2(i1, i2);
        }

        public static async Task DoSomething2(int i1, int i2)
        {
            await Task.Run(() => Console.WriteLine(i1 - i2));
           
        }
    }
}
