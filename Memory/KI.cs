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
                if (value == "Normal" || value == "Schwer") {
                    _difficulty = value ?? throw new System.ArgumentNullException(
                                                "Kein Schwierigkeitsgrad vorhanden!");
                } else {
                    throw new System.ArgumentException("Schwierigkeitsgrad ist nicht Normal oder Schwer!");
                }
                
            }
        }

        public KI(string difficulty, bool aktiveRunde) :base(aktiveRunde) {
            Difficulty = difficulty;
        }

        public override void Gedaechtnis(string karte, int zeile, int spalte) {
            base.Gedaechtnis(karte, zeile, spalte);

        }

        public override string GetName() {
            return Difficulty;
        }

        public override void GedaechnisAbrufen() {

        }

        public override void Random() {

        }

        public override void GedaechnisLoeschen() {

        }

        public override void ButtonDeaktivieren() {

        }
    }
}
