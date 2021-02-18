using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.Reflection;
using System.IO;

namespace LessonsAPI
{
    public class Win32
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr MessageBox(IntPtr hWnd, string text, string caption, long type);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string ClassName, string WindowName);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool DestroyWindow(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int SendMessage(IntPtr hWnd, Int32 msg, ushort wParam, int lParam);
    }
    class Program
    {
        //public static void Hello(object t)
        //{
        //    for (int i = 0; i < 100; i++)
        //    {
        //        Console.WriteLine("Hello " + t + ' ' + i);
        //    }
        //    ((Timer)t).Dispose();
        //}

        //public static void HelloTH(object t)
        //{
        //    for (int i = 0; i < 100; i++)
        //    {
        //        Console.WriteLine("Hello " + t + ' ' + i);
        //    }

        //}

        public static void Max(object t)
        {
            int max = ((int[])t).Max();
            Console.WriteLine("Max = {0}", max);
        }
        public static void Min(object t)
        {
            int min = ((int[])t).Min();
            Console.WriteLine("Min = {0}", min);
        }
        public static void AVG(object t)
        {
            double avg = ((int[])t).Average();
            Console.WriteLine("AVG = {0}", avg);
        }
        public static void Print(object t)
        {
            int[] arr = ((int[])t);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + ",  ");
            }
            string path = "D:\\text.txt";
            using (StreamWriter sw = new StreamWriter(path, false, Encoding.Default))
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    sw.WriteLine(arr[i]);
                }
            }
            Console.WriteLine();
            Console.WriteLine("\nДанные записаны в файл по адресу - {0}", path);
        }

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World");
            //Timer t = new Timer(Hello);
            //t.Change(1000, 500);
            int n = 10000;
            Random rand = new Random();
            int[] arr = new int[n];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next();
            }

            Thread print = new Thread(Print);
            print.Start(arr);
            print.Join();
            Thread max = new Thread(Max);
            max.Start(arr);
            Thread min = new Thread(Min);
            min.Start(arr);
            Thread avg = new Thread(AVG);
            avg.Start(arr);

            //Thread thread1 = new Thread(HelloTH);
            //thread1.Start("Mikolka");
            Console.ReadKey();
        }

        static void Main2(string[] args)
        {
            #region WinAPI
            //Console.WriteLine("HELLO API!!!");

            //Win32.MessageBox(new IntPtr(0), "Hello Word", "Hello Dialog", 0x00000000L|0x00000040L);
            //IntPtr p = Win32.FindWindow(null, "Документ - WordPad");
            //Console.WriteLine(p);
            //Win32.DestroyWindow(p);
            //Win32.SendMessage(p, 0x0010, 0, 0);
            #endregion

            //ProcessStartInfo infop = new ProcessStartInfo("notepad.exe");
            //Process p = Process.Start(infop);

            //AppDomain appDomain = AppDomain.CreateDomain("new domain");
            //Assembly assembly = appDomain.Load(AssemblyName.GetAssemblyName("Library1.dll"));
            //assembly.GetModule("Library1.dll").GetType("Library1.Library1").GetMethod("HelloWorld").Invoke(null, null);
            //AppDomain.Unload(appDomain);

            ProcessStartInfo infop = new ProcessStartInfo();
            Process p = new Process();
            bool b = true;
            while (b)
            {
                Console.WriteLine("Выберите приложение для запуска:\n\n" +
                    "\t1. Блокнот\n" +
                    "\t2. Paint\n" +
                    "\t3. Калькулятор\n" +
                    "\t4. Norton_Comander\n");
                Console.Write("Ваш выбор: ");
                string v = Console.ReadLine();
                int var = Convert.ToInt32(v);
                switch (var)
                {
                    case 1:
                        infop.FileName = "notepad.exe";
                        p = Process.Start(infop);
                        break;
                    case 2:
                        infop.FileName = "paint.exe";
                        p = Process.Start(infop);
                        break;
                    case 3:
                        infop.FileName = "calc.exe";
                        p = Process.Start(infop);
                        break;
                    case 4:
                        infop.FileName = @"d:\Users\MIKOLKA\EXAM от 11.02.2021\NortonCommander\NortonCommander\NortonCommander\bin\Debug\NortonCommander.exe";
                        p = Process.Start(infop);
                        break;
                    default:
                        break;
                }
                Console.WriteLine();
                Console.Write("Выйти с приложения (Да-1, Нет-2): ");
                string v2 = Console.ReadLine();
                int var2 = Convert.ToInt32(v2);
                if (var2 == 1)
                {
                    b = false;
                    p.CloseMainWindow();
                }

                Console.WriteLine();
                Console.WriteLine("Выход");
            }

            Console.ReadKey();
            //p.CloseMainWindow();
        }
    }
}
