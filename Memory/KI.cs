/*
 * Kindklasse von Spieler
 * Autoren: Alexander Bletsch, Anna Stork
 * Erstellt: 09.06.22
 */

namespace Memory {
    public class KI : Spieler {
        int _difficulty;

        public int Difficulty {
            get => _difficulty;
            set {
                _difficulty = value;
            }
        }

        public KI(int difficulty) :base() {
            Difficulty = difficulty;
        }

        public override void FeldAnschauen() { 
            
        }

        public override void Gedaechtnis() {
            
        }

        public int GetDifficulty() {
            return Difficulty;
        }
    }
}
