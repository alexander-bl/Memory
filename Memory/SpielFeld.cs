using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory {
    public class SpielFeld {
        string[,] _feld;
        Karten _karten;

        public string[,] Feld {
            get => _feld;
            set {
                _feld = value;
            }
        }

        public Karten Karten { get => _karten; set => _karten = value; }

        public SpielFeld(Karten _karten) {
            Feld = _feld;
            Karten = _karten;
        }

        public void ErzeugeSpielfeld() {

            Random rnd = new Random();
            int s = 4, z = 4;

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

                    string[] Begriffe = Karten.GetKarten();
                    Feld[i, n] = Begriffe[zufallszahl];

                }
            }

            

        }

    }



    }
}