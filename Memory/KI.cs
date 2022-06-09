/*
 * Kindklasse von Spieler
 * Autoren: Alexander Bletsch, Anna Stork
 * Erstellt: 09.06.22
 */

namespace Memory {
    public class KI : Spieler {
        string _difficulty;

        public string Difficulty {
            get => _difficulty;
            set {
                _difficulty = value;
            }
        }

        public KI(string difficulty) :base() {
            Difficulty = difficulty;
        }

        public override void FeldAnschauen() { 
            
        }

        public override void Gedaechtnis() {
            
        }

        public override int GetName() {
            return Difficulty;
        }
    }
}
