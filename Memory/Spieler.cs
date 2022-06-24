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
        List<KnownCard> _geseheneKarten;//Liste aller bereits gesehenen Karten
        Tuple<KnownCard, KnownCard> _offeneKarten;//Aktuell aufgedeckten Karten
        bool _aktiveRunde;//Ist Spieler aktuell an der Reihe?
        int _anzahlGefundenerPaare;//Anzahl aller Gefundenen Karten paare

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="aktiveRunde"></param>
        protected Spieler(bool aktiveRunde) {
            GeseheneKarten = new List<KnownCard>();
            OffeneKarten = new Tuple<KnownCard, KnownCard>(
                new KnownCard("", 0, 0), new KnownCard("", 0, 0));

            AktiveRunde = aktiveRunde;
            AnzahlGefundenerPaare = 0;
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
                _offeneKarten = value ?? throw new ArgumentNullException(
                                   "keine Offenen Karten angegeben!");
            }
        }

        public bool AktiveRunde { get => _aktiveRunde; set => _aktiveRunde = value; }
        public int AnzahlGefundenerPaare {
            get => _anzahlGefundenerPaare;
            set {
                if (value <= 0 || value > 8) {
                    throw new ArgumentOutOfRangeException(
                        "Anzahl der Gefundenen Paare ist größer als 8 oder kleiner als 0!");
                }
                _anzahlGefundenerPaare = value;
            }
        }

        /// <summary>
        /// Speichern der gesehenen Karten
        /// </summary>
        /// <param name="karte"></param>
        /// <param name="zeile"></param>
        /// <param name="spalte"></param>
        public virtual void Gedaechtnis(KnownCard card) {
            GeseheneKarten.Add(card);//Speicher neue Karte ins Gedächniss 
        }

        /// <summary>
        /// Zufällige Karte auswählen
        /// </summary>
        /// <param name="spielFeld"></param>
        /// <returns></returns>
        public abstract KnownCard Random(SpielFeld spielFeld, Random rnd, KnownCard aktcard);

        /// <summary>
        /// Handled die Offenen Karten und Zeit des aktuell Spielenden Spielers
        /// </summary>
        /// <param name="card"></param>
        /// <returns>Ist Zweite Karte aufgedeckt?</returns>
        public abstract bool OffeneKartenHandler(KnownCard card);
    }
}
