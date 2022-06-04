using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Memory {
    abstract public class Spieler {
        int _highscore;

        public int Highscore {
            get => _highscore;
            set {
                _highscore = value;
            }
        }
    }
}