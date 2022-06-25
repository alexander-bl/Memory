using System;
using System.Diagnostics;
using System.Windows.Controls;
using System.Collections.Generic;
/*
 * Kindklasse von Spieler
 * Autoren: Alexander Bletsch, Anna Stork
 * Erstellt: 09.06.22
 */
namespace Memory {
    public class Mensch : Spieler {
        string _name;//Name des Menschen
        int _score;//Punktzahl des Menschen
        Stopwatch _stopwatch;//Stopuhr zur Zeitmessung

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="aktiveRunde"></param>
        public Mensch(string name, bool aktiveRunde) : base(aktiveRunde) {
            Name = name;
            Score = 0;
            Stopwatch = new Stopwatch();    
        }

        public string Name {
            get => _name;
            set {
                if (value == null) {
                    throw new ArgumentNullException(
                                    "Kein Name Vorhanden");
                }
                if (value.Length < 2) {
                    throw new ArgumentOutOfRangeException("Name ist zu kurz! Mindestens 2 Zeichen lang.");
                }
                _name = value;
            }
        }

        public int Score {
            get => _score;
            set {
                if (value < 0) {
                    throw new ArgumentOutOfRangeException("Punktzahl ist kleiner als 0!");
                }
                _score = value;
            }
        }

        public Stopwatch Stopwatch {
            get => _stopwatch;
            set {
                _stopwatch = value ?? throw new ArgumentNullException(
                                        "Keine Stopuhr vorhanden!");
            }
        }

        /// <summary>
        /// Speichern("Merken") aller aufgedeckten Karten
        /// </summary>
        /// <param name="karte"></param>
        /// <param name="zeile"></param>
        /// <param name="spalte"></param>
        public override void Gedaechtnis(KnownCard card) {
            base.Gedaechtnis(card);
        }

        /// <summary>
        /// Auswahl einer zufälligen Karte
        /// </summary>
        /// <param name="buttons"></param>
        /// <returns></returns>
        public override Button Random(List<Button> buttons) {
            int x;
            do {
                Random rnd = new Random();
                x = rnd.Next(buttons.Count);//Auswahl Zufälliger Button
            } while (!buttons[x].IsEnabled);//Wenn ausgesuchter Button deaktiviert ist nehme anderen zufälligen Button 

            return buttons[x];
        }

        /// <summary>
        /// Handled die Offenen Karten und Zeit des aktuell Spielenden Menschen
        /// </summary>
        /// <param name="card"></param>
        /// <returns>Ist Zweite Karte aufgedeckt?</returns>
        public override bool OffeneKartenHandler(KnownCard card) {
            //Test ob Aufgedeckte Karte erste oder zweite Karte ist
            if (OffeneKarten.Item1.Karte == "") {
                KnownCard emptyCard = new KnownCard("", 0, 0);
                Stopwatch.Start();
                OffeneKarten = new Tuple<KnownCard, KnownCard>(card, emptyCard);
                return false;//false weil aufgedeckte Karte die erste Karte der Runde ist
            } else {
                Stopwatch.Stop();
                 OffeneKarten = new Tuple<KnownCard, KnownCard>(OffeneKarten.Item1, card);
                return true;//true weil aufgedeckte Karte die zweite Karte der Runde ist
            }
        }
    }
}
