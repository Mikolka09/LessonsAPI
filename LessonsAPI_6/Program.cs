using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonsAPI_6
{
    class Program
    {
        static void Main(string[] args)
        {
            unsafe
            {
                int c = 1;
                int* p = &c;
                (*p)++;
                Console.WriteLine(*p);
                int c1 = 2;
                Squere(&c1);
                Console.WriteLine(c1);
            }

            Console.ReadLine();
        }

        unsafe static void Squere(int* v)
        {
            *v *= *v;
        }
    }
}
