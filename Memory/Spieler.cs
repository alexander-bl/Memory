using System;

namespace Memory {
    abstract public class Spieler {
        int _highscore;
        int _score;
        //TODO Speichern der bereits gesehenen Karten

        public Spieler(int highscore, int score) {
            Highscore = highscore;
            Score = score;
        }

        public int Highscore {
            get => _highscore;
            set {
                if (value < 0) {
                    throw new ArgumentOutOfRangeException("Highscore ist kleiner als 0!");
                }
                _highscore = value;
            }
        }

        public int Score {
            get => _score;
            set {
                if (value < 0) {
                    throw new ArgumentOutOfRangeException("Score ist kleiner als 0!");
                }
                _score = value;
            }
        }

        public virtual void FelderMerken() {
            
        }

        public abstract void FeldAnschauen();
    }
}