using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory {
    public class Feld {
        Karten _kartenDeck;
        int[] _spielFeld;

        public Feld(int[] feld, Karten kartenDeck) {
            SpielFeld = feld;
            KartenDeck = kartenDeck;
        }



        public Karten KartenDeck { get => _kartenDeck; set => _kartenDeck = value; }
        public int[] SpielFeld {
            get => _spielFeld;
            set {
                _spielFeld = value;
            }
        }
    }
}
