namespace Memory {
    public class KI : Spieler {
        int _difficulty;

        public int Difficulty {
            get => _difficulty;
            set {
                _difficulty = value;
            }
        }

        public KI(int difficulty, int highscore, int punkte) :base(highscore, punkte) {
            Difficulty = difficulty;
        }

        public override void FeldAnschauen() { 
        
        }

        public override void FelderMerken() {
            base.FelderMerken();
        }
    }
}
