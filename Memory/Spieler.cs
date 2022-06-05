namespace Memory {
    public class Spieler {
        int _highscore;
        int _punkte;

        public Spieler(int highscore, int punkte) {
            Highscore = highscore;
            Punkte = punkte;
        }

        public int Highscore {
            get => _highscore;
            set {
                _highscore = value;
            }
        }

        public int Punkte {
            get => _punkte;
            set {
                _punkte = value;
            }
        }

        public virtual void choice() {


        }
    }
}