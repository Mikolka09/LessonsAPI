using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.Reflection;

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
        static void Main(string[] args)
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
