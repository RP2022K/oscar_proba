using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdatokKezelese
{
    [Serializable]
    internal class Lap
    {
        public int Szin {set; get; }
        public int Ertek { set; get; }
        private string szinek = "♥♦♣♠";
        public override string ToString()
        {
            string ertek = "";
            ertek += Ertek;
            switch (Ertek)
            {
                case 11:
                    ertek = "J";    break;
                case 12:
                    ertek = "Q";    break;
                case 13:
                    ertek = "K";    break;
                case 14:
                    ertek = "A";    break;

            }
            return $"[{szinek[Szin-3]} {ertek}]";
        }
    }
}
