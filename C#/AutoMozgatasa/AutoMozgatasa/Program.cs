using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoMozgatasa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"({Console.BufferWidth}x{Console.BufferHeight})");
            /*Console.WindowLeft =50;
            Console.WindowTop = 20;
            Console.SetWindowSize(115, 55);
            Console.BufferWidth = 115;
            Console.BufferHeight = 55;
             for (int sor = 1; sor <= 55; sor++)        
            {
                for (int oszlop = 1; oszlop <= 115; oszlop++)
                {
                    Console.Write("s");
                }
            }

            Console.WriteLine("Balogh Balázs (c) 2023");
            Console.Write("Nyomj egy billentyűt a törléshez...");
            Console.ReadKey(true);
            Console.Clear();
            //Console.ReadKey();
            Thread.Sleep(2500);
            */



            /* Console.SetCursorPosition(Console.WindowWidth-3,25);
             Console.Write(auto);
             Thread.Sleep(2000);
            */

            string auto = "A-1";
            string auto1 = "B-2";
            int poz = Console.WindowWidth - 3;

            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(poz, 5);
                Console.Write(auto);
                if (poz > 3)
                {
                    poz -= 3;
                    
                }
                else
                {
                    break;
                }              
                Thread.Sleep(100);
            }
            Thread.Sleep(2000);
        }
    }
}
