using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace LessonsAPI_3
{
    class Program
    {
        delegate int AsyncSum(int size);
        delegate int AsyncFact(int size);
        delegate int AsyncStep(int a, int b);
        delegate int AsyncCount(string st, char[] arr);

        static void Main(string[] args)
        {
            //FileStream fs = new FileStream("D:\\Probnik.txt", FileMode.Open);
            //byte[] b = new byte[256];
            //int br = fs.Read(b, 0, b.Length);
            //IAsyncResult ar = fs.BeginRead(b, 0, b.Length, FSCallback, fs);
            //fs.BeginRead(b, 0, b.Length, (IAsyncResult ar) => {
            //int br = fs.EndRead(ar);
            //Console.WriteLine(br); }, null);
            //while(!ar.IsCompleted) //редко пользуются
            //{
            //    //scas
            //    //asdfsa7
            //    //asfsasa
            //    Thread.Sleep(100);
            //}
            //while (!ar.AsyncWaitHandle.WaitOne(100)) //редко пользуются
            //{
            //    //scas
            //    //asdfsa7
            //    //asfsasa
            //}
            //int br = fs.EndRead(ar);
            //AsyncSum asum = (int size) => {
            //    int sum = 0;
            //    for (int i = 0; i < size; i++)
            //    {
            //        sum += i;
            //    }
            //    return sum;
            //};
            //asum.BeginInvoke(100, (IAsyncResult ar) => { Console.WriteLine(asum.EndInvoke(ar)); }, null);

            //Console.Write("Введите число: ");
            //int numb = Convert.ToInt32(Console.ReadLine());
            //bool f1 = false, f2 = false;
            //int numb1 = numb / 2;
            //int numb2 = numb - numb1;
            //int result = 1;
            //AsyncFact afact1 = Fact;
            //AsyncFact afact2 = Fact;
            //IAsyncResult ar1 = afact1.BeginInvoke(numb1, null, null);
            //IAsyncResult ar2 = afact2.BeginInvoke(numb2, null, null);
            //while (!ar1.IsCompleted || !ar2.IsCompleted)
            //{
            //    if (ar1.IsCompleted && f1 == false)
            //    {
            //        result *= afact1.EndInvoke(ar1);
            //        f1 = true;
            //    }
            //    if (ar2.IsCompleted && f2 == false)
            //    {
            //        result *= afact2.EndInvoke(ar2);
            //        f2 = true;
            //    }
            //}
            //Console.WriteLine($"Факториал числа {numb} = {result}");

            //Задача 7
            //Console.Write("Введите число: ");
            //int numb = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Введите степень: ");
            //int step = Convert.ToInt32(Console.ReadLine());
            //bool f1 = false, f2 = false;
            //int step1 = step / 2;
            //int step2 = step - step1;
            //int result = 1;
            //AsyncStep a1 = Stepen;
            //AsyncStep a2 = Stepen;
            //IAsyncResult ar1 = a1.BeginInvoke(numb, step1, null, null);
            //IAsyncResult ar2 = a2.BeginInvoke(numb, step2, null, null);
            //while (!ar1.IsCompleted || !ar2.IsCompleted)
            //{
            //    if (ar1.IsCompleted && f1 == false)
            //    {
            //        result *= a1.EndInvoke(ar1);
            //        f1 = true;
            //    }
            //    if (ar2.IsCompleted && f2 == false)
            //    {
            //        result *= a2.EndInvoke(ar2);
            //        f2 = true;
            //    }
            //}
            //Console.WriteLine($"Числов {numb} в степени {step} = {result}");

            //Задание 8
            char[] gl = { 'а', 'о', 'у', 'ы', 'э', 'я', 'ё', 'ю', 'и', 'е' };
            char[] sgl = { 'б', 'в', 'г', 'д', 'ж', 'з', 'й', 'л', 'м', 'н', 'р', 'п', 'ф', 'к', 'т', 'ш', 'с', 'х', 'ц', 'ч', 'щ' };
            char[] symb = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '{', '}', '|', '\\', '/', ':', ';', '.', ',', '-', '?', '[', ']' };
            Console.Write("Введите текст: ");
            string txt = Console.ReadLine().ToLower();
            AsyncCount glCnt = CountTxt;
            AsyncCount sglCnt = CountTxt;
            AsyncCount symbCnt = CountTxt;
            bool f1 = false, f2 = false, f3 = false;
            IAsyncResult arg = glCnt.BeginInvoke(txt, gl, null, null);
            IAsyncResult ars = sglCnt.BeginInvoke(txt, sgl, null, null);
            IAsyncResult arsym = symbCnt.BeginInvoke(txt, symb, null, null);
            while (!arg.IsCompleted || !ars.IsCompleted || !arsym.IsCompleted)
            {
                if(arg.IsCompleted && f1 == false)
                {
                    Console.WriteLine($"Количество гласных букв = {glCnt.EndInvoke(arg)}");
                    f1 = true;
                }
                if (ars.IsCompleted && f2 == false)
                {
                    Console.WriteLine($"Количество согласных букв = {sglCnt.EndInvoke(ars)}");
                    f2 = true;
                }
                if (arsym.IsCompleted && f3 == false)
                {
                    Console.WriteLine($"Количество символов = {symbCnt.EndInvoke(arsym)}");
                    f3 = true;
                }
            }

            Console.ReadLine();

        }

        static int Fact(int size)
        {
            int fact = 1;
            for (int i = 1; i < size; i++)
            {
                fact *= i;
            }
            return fact;
        }

        static int Stepen(int a, int b)
        {
            int st = 1;
            for (int i = 0; i < b; i++)
            {
                st *= a;
            }
            return st;
        }

        static int CountTxt(string st, char[] arr)
        {
            int cnt = 0;
            foreach (var item in st)
            {
                if(arr.Contains(item))
                    cnt++;
            }
            return cnt;
        }

        //static void FSCallback(IAsyncResult ar)
        //{
        //    FileStream fs = (FileStream)ar.AsyncState;
        //    int br = fs.EndRead(ar);
        //    Console.WriteLine(br);
        //}

    }
}
