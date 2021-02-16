using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

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
            //Console.WriteLine("HELLO API!!!");

            //Win32.MessageBox(new IntPtr(0), "Hello Word", "Hello Dialog", 0x00000000L|0x00000040L);
            IntPtr p = Win32.FindWindow(null, "Документ - WordPad");
            Console.WriteLine(p);
            //Win32.DestroyWindow(p);
            Win32.SendMessage(p, 0x0010, 0, 0);

            Console.ReadKey();
        }
    }
}
