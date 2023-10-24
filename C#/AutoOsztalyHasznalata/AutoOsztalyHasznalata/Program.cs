using System;
using System.Threading;

namespace AutoOsztalyHasznalata
{
    internal class Program
    {
       
        class Auto
        {

            private int sebesseg = 0;
            private string rendszam = "";


            public void setsebesseg(int sebesseg)
            {
                if (sebesseg >=0) {
                    this.sebesseg = sebesseg;
                }
                else
                {
                    Console.Write("!!! Hibás adat !!!  !!ROSSZ SEBESSÉG!!    ");
                }
            }

            public int getsebesseg ()
            {
                return sebesseg;
            }

            public void setrendszam(string rendszam)
            {
                this.rendszam = rendszam;
            }

            public string getrendszam()
            {
                return rendszam;
            }

            public string autoadatai()
            {
               return ("Az autó adatai: " + getrendszam() + "   " + getsebesseg() + "Km/h" + "\n");
            }
        } 
        static void Main(string[] args)
        {
            Auto a = new Auto();
            Auto b = new Auto();

            a.setrendszam("HZU-451");
            a.setsebesseg(70);
            Console.Write(a.autoadatai());

            b.setrendszam("HRF-852");
            b.setsebesseg(40);
            Console.Write(b.autoadatai());

            Thread.Sleep(4000);
        }
    }
}
