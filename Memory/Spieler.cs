using System;
using System.Collections.Generic;
/*
 * Elternklasse zu Mensch und KI
 * Autoren: Alexander Bletsch, Anna Stork
 * Erstellt: 09.06.22
 */
namespace Memory {
    abstract public class Spieler {
        int _score;
        List <KnownCard> _geseheneKarten;
        static int _runde;
        bool _aktiveRunde;

        protected Spieler(bool aktiveRunde) {
            Score = 0;
            Runde = 0;
            AktiveRunde = aktiveRunde;
        }

        public int Score {
            get => _score;
            set {
                if (value < 0 || value > 8) {
                    throw new ArgumentOutOfRangeException(
                                "Score ist kleiner als 0 oder Groesser als 8!");
                }
                _score = value;
            }
        }

        public List<KnownCard> GeseheneKarten {
            get => _geseheneKarten;
            set {
                _geseheneKarten = value ?? throw new ArgumentNullException(
                                   "keine angeschauten Karten angegeben!");
            }
        }

        public static int Runde {
            get => _runde;
            set {
                if (value < 0) {
                    throw new ArgumentOutOfRangeException("Rundenanzahl ist kleiner als 0!");
                }
                _runde = value;
            }
        }

        public bool AktiveRunde { get => _aktiveRunde; set => _aktiveRunde = value; }

        public virtual void Gedaechtnis(string karte, int zeile, int spalte) {
            KnownCard neueKarte = new KnownCard(karte, zeile, spalte);
            GeseheneKarten.Add(neueKarte);
        }

        public abstract void FeldAnschauen();

        public abstract string GetName();
    }
}
