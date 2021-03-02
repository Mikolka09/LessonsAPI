using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LessonsAPI_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task(() => Console.WriteLine("Hello"));
            task.Start();
            //task.Wait(); //останавливает основной поток пока не выполнится фоновый
            Task<int> task2 = new Task<int>(() => 2 * 8);
            task2.Start();
            Console.WriteLine(task2.Result);
            Task task3 = Task.Run(() => 2 + 8).
                ContinueWith((Task<int> t) => (double)t.Result * t.Result).
                ContinueWith((Task<double> t) => t.Result / 3).
                ContinueWith((Task<double> t) => Console.WriteLine(t.Result));

            Parallel.Invoke(() => Console.WriteLine("H"), 
                            () => Console.WriteLine("E"),
                            () => Console.WriteLine("L"),
                            () => Console.WriteLine("L"),
                            () => Console.WriteLine("O"));

            Console.ReadKey();
        }
    }
}
