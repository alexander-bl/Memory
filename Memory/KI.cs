namespace Memory {
    public class KI : Spieler {
        int _difficulty;

        public int Difficulty {
            get => _difficulty;
            set {
                _difficulty = value;
            }
        }
    }
}
