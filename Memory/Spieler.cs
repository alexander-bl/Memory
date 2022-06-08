using System;

namespace Memory {
    abstract public class Spieler {
        int _score;
        (string karte, int zeile, int spalte)[] _geseheneKarten;
        
        protected Spieler() {
            Score = 0;
        }

        public int Score {
            get => _score;
            set {
                if (value < 0) {
                    throw new ArgumentOutOfRangeException(
                                "Score ist kleiner als 0!");
                }
                _score = value;
            }
        }

        public (string karte, int zeile, int spalte)[] GeseheneKarten {
            get => _geseheneKarten;
            set {
                if (value == null) {
                    throw new ArgumentNullException(
                                "keine angeschauten Karten angegeben!");
                }
                _geseheneKarten = value;
            }
        }

        public abstract void Gedaechtnis();

        public abstract void FeldAnschauen();
    }
}
