using System;
using System.Collections.Generic;
/*
 * Elternklasse zu Mensch und KI
 * Autoren: Alexander Bletsch, Anna Stork
 * Erstellt: 09.06.22
 */
namespace Memory {
    abstract public class Spieler {
        List<KnownCard> _geseheneKarten;
        //Offene Karten abspeoíchern;
        bool _aktiveRunde;

        protected Spieler(bool aktiveRunde) {
            AktiveRunde = aktiveRunde;
        }

        public List<KnownCard> GeseheneKarten {
            get => _geseheneKarten;
            set {
                _geseheneKarten = value ?? throw new ArgumentNullException(
                                   "keine angeschauten Karten angegeben!");
            }
        }

        public bool AktiveRunde { get => _aktiveRunde; set => _aktiveRunde = value; }

        public virtual void Gedaechtnis(string karte, int zeile, int spalte) {
            KnownCard neueKarte = new KnownCard(karte, zeile, spalte);
            GeseheneKarten.Add(neueKarte);
        }

        public abstract void Random();

        public abstract void GedaechnisLoeschen();

        public abstract void ButtonDeaktivieren();

        public abstract string GetName();
    }
}
