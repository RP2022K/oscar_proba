using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AdatFeldolgozas
{
    struct Zene
    {
        int ado;
        int perc;
        int masodperc;
        string eloado;
        string cim;

        public int Ado { get  {return ado;}   }
        public int Perc { get  { return perc; } }
        public int Masodperc { get { return masodperc; } }
        public string Eloado { get { return eloado; } }
        public string Cim { get { return cim; } }
    
        public Zene(string sor)
        {
            string[] r1 = sor.Split(':');
            cim = r1[1];
            string[] r2 = r1[0].Split(' ');
            ado = int.Parse(r2[0]);
            perc = int.Parse(r2[1]);
            masodperc = int.Parse(r2[2]);
            //eloado = (r2[3]);
            eloado = "";
            for (int i = 3; i<r2.Length; i++ )
            {
                eloado += (r2[i] + " ");
            }
            eloado = eloado.Trim();
        }       
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Zene> zenek = new List<Zene>();
            StreamReader file = new StreamReader("zenek.txt");
            while (!file.EndOfStream)
            {
                //Console.WriteLine(file.ReadLine());
                //Thread.Sleep(75);
                Zene z = new Zene(file.ReadLine());
                zenek.Add(z);
            }
            //Console.ReadKey();
            file.Close();
            foreach (Zene z in zenek) {/* igy is be tudnánk járni az elemeket!*/}

            var linq1 = from zene in zenek
                        select new
                        {
                            Ado = zene.Ado,
                            Perc = zene.Perc,
                            Masodperc = zene.Masodperc
                        };

            foreach (var z in linq1)
            {
                Console.WriteLine($"{z.Ado}. Rádió adó: {z.Perc,2:00}:{z.Masodperc,2:00}");
            }
            int[] a = { 1, 2, 4, 7 };
            int[] b = { 1, 3, 5, 6, 7 };
            //Console.WriteLine(a.Union(b));
            Console.Write("{ ");
            foreach (var elem in a.Union(b).OrderBy(x => x))
            {
                Console.Write(elem + ", ");
            }
            Console.WriteLine("}");

            var linq2 = from adat in linq1
                        group adat by adat.Ado
                        into csoport
                        select new
                        {
                            Ado = csoport.Key,
                            Ora = csoport.Sum(sor => sor.Perc) / 60,
                            Perc = (csoport.Sum(sor => sor.Masodperc) / 60 + csoport.Sum(sor=>sor.Perc)) % 60,
                            Masodperc = csoport.Sum(sor => sor.Masodperc) % 60,
                        };
            foreach (var adat in linq2)
            {
                Console.WriteLine($"{adat.Ado}. Rádió adó: {adat.Ora,2:00}:{adat.Perc,2:00}:{adat.Masodperc,2:00}");
            }
            Console.ReadKey();
        }
    }
}
