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
        public int[] Feld {
            get => _feld;
            set {
                _feld = value;
            }
        }

        public SpielFeld(Spieler spieler, int[] feld) {
            Spieler = spieler;
            Feld = feld;
        }
    }
}
