using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
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
        int _anzahlGefundenerPaare;//Anzahl aller Richtigen Gefundenen Karten paare
        List<KnownCard> _verfuegbareKarten; //Liste der noch verfügbaren Karten

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
            VerfuegbareKarten = new List<KnownCard>();
        }

        protected Spieler(List<KnownCard> verfuegbareKarten, List<KnownCard> geseheneKarten,
            Tuple<KnownCard, KnownCard> offeneKarten, bool aktiveRunde, 
            int anzahlGefundenerPaare) {

            VerfuegbareKarten = verfuegbareKarten;
            GeseheneKarten = geseheneKarten;
            OffeneKarten = offeneKarten;
            AktiveRunde = aktiveRunde;
            AnzahlGefundenerPaare = anzahlGefundenerPaare;
        }

        public List<KnownCard> VerfuegbareKarten {
            get => _verfuegbareKarten;
            set {
                _verfuegbareKarten = value ?? throw new ArgumentNullException(
                                        "Keine Vervügbaren Karten vorhanden!");
            }
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
                if (value < 0 || value > 8) {
                    throw new ArgumentOutOfRangeException(
                        "Anzahl der Gefundenen Paare ist größer als 8 oder kleiner als 0!");
                }
                _anzahlGefundenerPaare = value;
            }
        }

        /// <summary>
        /// Speichern der gesehenen Karten
        /// </summary>
        /// <param name="card"></param>
        public virtual void Gedaechtnis(KnownCard card) {
            GeseheneKarten.Add(card);//Speicher neue Karte ins Gedächniss 
        }

        /// <summary>
        /// Zufällige Karte auswählen
        /// </summary>
        /// <param name="rnd"></param>
        /// <param name="aktcard"></param>
        /// <returns></returns>
        public virtual KnownCard Random(Random rnd, KnownCard aktcard) {
            KnownCard card;
            int zahl;
            do {
                zahl = rnd.Next(VerfuegbareKarten.Count);
                card = VerfuegbareKarten[zahl];

            } while (aktcard.Spalte == card.Spalte && aktcard.Zeile == card.Zeile);
            //Wenn ausgesuchte Karte gleich bereits ausgewählte Karte nehme andere Karte

            return card;
        }

        /// <summary>
        /// Handled die Offenen Karten und Zeit des aktuell Spielenden Spielers
        /// </summary>
        /// <param name="card"></param>
        /// <returns>Ist Zweite Karte aufgedeckt?</returns>
        public abstract bool OffeneKartenHandler(KnownCard card);
    }
}
