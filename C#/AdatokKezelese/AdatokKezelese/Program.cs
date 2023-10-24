using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AdatokKezelese
{
    internal class Program
    {
        static void Main(string[] args)
        {
           /* Lap korAsz = new Lap();
            korAsz.Szin = 3;
            korAsz.Ertek = 14;
            Console.WriteLine(korAsz);
            Console.ReadKey();*/

            Pakli p = new Pakli();

            /*foreach (Lap l in p.Lapok)
            {
                Console.WriteLine(l);
            }

            Console.ReadKey();*/
            p.Osztas(5);
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fsoutput = new FileStream("lap.bin",FileMode.Create,FileAccess.Write, FileShare.None);
            Lap korAsz = new Lap();
            korAsz.Szin = 5;
            korAsz.Ertek = 12;
            /*bf.Serialize(fsoutput, korAsz);
            fsoutput.Close();*/
            using (fsoutput)
            {
                bf.Serialize(fsoutput, korAsz);
            }

            FileStream fsinput = new FileStream("lap.bin",FileMode.Open,FileAccess.Read,FileShare.None);
            using (fsinput)
            {
                korAsz = (Lap)bf.Deserialize(fsinput);
            }
            Console.WriteLine(korAsz);
            Console.ReadKey();
        }
    }
}
