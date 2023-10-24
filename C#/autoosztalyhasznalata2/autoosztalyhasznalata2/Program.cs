using System;

namespace AutoOsztalyHasznalata
{
    struct Car
    {
        int sebesseg;
        string rendszam;
        public int Sebesseg
        {
            get { return sebesseg; }
            set { if (value > 0 && value < 6) { sebesseg = value; } }
        }
        public string Rendszam
        {
            set { rendszam = value; }
            get { return rendszam; }
        }
    }

    class Auto
    {
        int sebesseg;
        string rendszam;
        public int Sebesseg
        {
            get { return sebesseg; }
            set { if (value > 0 && value < 6) { sebesseg = value; } }
        }
        public string Rendszam
        {
            set { rendszam = value; }
            get { return rendszam; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Car c = new Car();
            //Auto a = new Auto()
            Random rand = new Random();
            Car[] autok1 = new Car[5];
            Auto[] autok2 = new Auto[5];
            for (int i = 0; i < autok1.Length; i++)
            {
                Char c = (char)(rand.Next(0, 26) + 65);
                autok1[i].Sebesseg = rand.Next(1, 6);
                autok1[i].Rendszam = "";
                autok1[i].Rendszam += c;
                autok1[i].Rendszam += "-";
                autok1[i].Rendszam += autok1[i].Sebesseg;
                autok2[i] = new Auto();
                autok2[i].Sebesseg = rand.Next(-1, 4);
            }
            Console.CursorVisible = false;
            Console.SetCursorPosition(40, 7);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(autok1[4].Rendszam);
            Console.ReadKey(true);
            Console.SetCursorPosition(40 - autok1[3].Sebesseg, 7);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(autok1[4].Rendszam);
            Console.ReadKey(true);
        }
    }
}
