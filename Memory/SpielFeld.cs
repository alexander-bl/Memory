using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory {
    public class SpielFeld {
        Spieler _spieler;
        string[,] _feld;
        Karten _karten;



        public Spieler Spieler {
            get => _spieler;
            set {
                _spieler = value;
            }
        }

        public string[,] Feld {
            get => _feld;
            set {
                _feld = value;
            }
        }

        public Karten Karten { get => _karten; set => _karten = value; }

        public SpielFeld(Spieler spieler, string[,] feld) {
            Spieler = spieler;
            Feld = feld;
        }

        public void ErzeugeSpielfeld() {

            Random rnd = new Random();
            int s = 4, z = 4;
            //string[] Begriffe = new string[8] { "Informatik", "C#", "Hello World", "Array", "Polymorphie", "Vererbung", "Visual Studio", "Properties" };


            int[] anzahl = new int[8];

            bool ok = false;
            int zufallszahl;

            for (int i = 0; i < z; i++)
            {
                for (int n = 0; n < s; n++)
                {
                    do
                    {
                        zufallszahl = rnd.Next(0, 8);
                        ok = false;

                        for (int j = 0; j < zufallszahl + 1; j++)
                        {
                            if (zufallszahl == j)
                            {
                                anzahl[j]++;
                            }
                        }

                        if (anzahl[zufallszahl] <= 2)
                        {
                            ok = true;
                        }

                    } while (!ok);

                    Feld[i, n] = [zufallszahl];

                }
            }

            

        }

    }



    }
}