using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masodik
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Hello");
            Console.WriteLine("Balogh Balázs");
            Console.ReadKey(true);
            */

            string szuldat = "";
            int poz = 0;

            Console.Write("Születési dátum (éééé-hh-nn): ");

            while (true)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                switch (poz)
                {
                    case 0:

                        if (cki.KeyChar == '1' || cki.KeyChar == '2')
                        {
                            Console.Write(cki.KeyChar);
                            szuldat += cki.KeyChar;
                            poz++;
                        }
                        break;

                    case 1:

                        if (poz == 1 && szuldat[0] == '1' && cki.KeyChar == '9')
                        {
                            Console.Write(cki.KeyChar);
                            szuldat += cki.KeyChar;
                            poz++;
                        }
                        else 
                        {
                            if (poz == 1 && szuldat[0] == '2' && cki.KeyChar == '0')
                            {
                                Console.Write(cki.KeyChar);
                                szuldat += cki.KeyChar;
                                poz++;
                            }
                            break;
                        }
                        break;
                }
                if (poz == 10) 
                {
                    break;
                }
            }
            string ketto = "";
            ketto += szuldat[0];
            ketto += szuldat[1];
            int kettoI = int.Parse(ketto);
            Console.ReadKey();
        }   
    }
}
