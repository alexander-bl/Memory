using System;
/*
 * Kindklasse von Spieler
 * Autoren: Alexander Bletsch, Anna Stork
 * Erstellt: 09.06.22
 */
namespace Memory {
    public class Mensch : Spieler {
        string _name;

        public Mensch(string name, bool aktiveRunde) : base(aktiveRunde) {
            Name = name;
        }

        public string Name {
            get => _name;
            set {
                if (value.Length < 2) {
                    throw new ArgumentOutOfRangeException("Name ist zu kurz! Mindestens 2 Zeichen lang.");
                }
                _name = value ?? throw new ArgumentNullException(
                                    "Kein Name Vorhanden");
            }
        }

        public override void Gedaechtnis(string karte, int zeile, int spalte) {
            base.Gedaechtnis(karte, zeile, spalte);

        }

        public override string GetName() {
            return Name;
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
