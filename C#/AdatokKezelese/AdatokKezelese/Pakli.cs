using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdatokKezelese
{
    internal class Pakli
    {
        private Lap[] lapok;
        public Lap[] Lapok { get { return lapok; } }
        public Pakli() 
        {
            lapok = new Lap[52];
            for (int szin = 3; szin <= 6; szin++)
            {
                for (int ertek = 2; ertek < 15; ertek++)
                {
                    lapok[(szin - 3) * 13 + ertek - 2] = new Lap();

                    lapok[(szin - 3) * 13 + ertek - 2].Szin = szin;

                    lapok[(szin - 3) * 13 + ertek - 2].Ertek = ertek;
                }
            }
            Keveres();
            
        }
        private void Keveres()
        {
            //Lap[] kevert = lapok;
            Lap[] kevert = new Lap[52];
            int j = 0;
            foreach (Lap l in lapok)
            {
                kevert[j++] = l;
            }
            Random rand = new Random();
            for (int db = 1; db <= 5; db++)
            {
                for (int i = 0; i < lapok.Length; i++)
                {
                    int vsz = rand.Next(0, 52);
                    Lap ideiglenes = kevert[vsz];
                    kevert[vsz] = kevert[i];
                    kevert[i] = ideiglenes;
                }
            }
            StreamWriter sw = new StreamWriter("kevert.pakli", true, Encoding.UTF8);
            foreach (Lap l in kevert)
            {
                sw.WriteLine(l);
            }
            sw.Close();
        }
        public void Osztas(int mennyi)
        {
            StreamReader sr = new StreamReader("kevert.pakli");
            for (int db =1; db <= mennyi; db++)
            {
                Console.Write(sr.ReadLine());
                Console.Write("  ");
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
