using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Controls;
/*
 * Elternklasse zu Mensch und KI
 * Autoren: Alexander Bletsch, Anna Stork
 * Erstellt: 09.06.22
 */
namespace Memory {
    abstract public class Spieler {
        List<KnownCard> _geseheneKarten;
        Tuple<KnownCard, KnownCard> _offeneKarten;
        bool _aktiveRunde;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="aktiveRunde"></param>
        protected Spieler(bool aktiveRunde) {
            GeseheneKarten = new List<KnownCard>();
            OffeneKarten = null;
            AktiveRunde = aktiveRunde;
        }

        public List<KnownCard> GeseheneKarten {
            get => _geseheneKarten;
            set {
                _geseheneKarten = value ?? throw new ArgumentNullException(
                                   "keine angeschauten Karten angegeben!");
            }
        }

        public Tuple<KnownCard, KnownCard> OffeneKarten {
            get => _offeneKarten;
            set {
                _offeneKarten = value;
            }
        }

        public bool AktiveRunde { get => _aktiveRunde; set => _aktiveRunde = value; }

        /// <summary>
        /// Speichern der gesehenen Karten
        /// </summary>
        /// <param name="karte"></param>
        /// <param name="zeile"></param>
        /// <param name="spalte"></param>
        public virtual void Gedaechtnis(string karte, int zeile, int spalte) {
            KnownCard neueKarte = new KnownCard(karte, zeile, spalte);
            GeseheneKarten.Add(neueKarte);//Speicher neue Karte ins Gedächniss 
        }

        /// <summary>
        /// Zufällige Karte auswählen
        /// </summary>
        /// <param name="buttons"></param>
        /// <returns></returns>
        public abstract Button Random(List<Button> buttons);

        /// <summary>
        /// Karte Anschauen
        /// </summary>
        /// <param name="stopwatch"></param>
        /// <param name="buttons"></param>
        public abstract void Karteanschauen(ref Stopwatch stopwatch, Button[] buttons);
    }
}
