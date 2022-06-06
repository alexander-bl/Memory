using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory {
    public class SpielFeld {
        Spieler _spieler;
        int[] _feld;

        

        public Spieler Spieler {
            get => _spieler;
            set {
                _spieler = value;
            }
        }

        public string[] Feld {
            get => _feld;
            set {
                _feld = value;
            }
        }
        

        public SpielFeld(Spieler spieler, string[] feld) {
            Spieler = spieler;
            Feld = feld;
        }

        public void ErzeugeSpielfeld()
        {
            Random rnd = new Random();
            int s = 4, z = 4;
            string[] Begriffe = new string[8] {"Informatik","C#","Hello World","Array","Polymorphie","Vererbung","Visual Studio","Properties"};
            
            int[] anzahl = new int[8];

            for (int i = 0; i < 16; i++)
            {
                int zufallszahl = rnd.Next(0, 8);

                if (zufallszahl == i)
                {
                    anzahl[i]++;
                }

                if (anzahl[i] <= 2)
                {
                    for (int j = 0; i < s; i++)
                    {
                        for (int n = 0; n < z; n++)
                        {
                            Feld[j, n] = Begriffe[zufallszahl];

                        }
                    }
                }
            }
           
        }
       
    }
}