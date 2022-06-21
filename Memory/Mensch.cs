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
        string _name;
        int _score;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="aktiveRunde"></param>
        public Mensch(string name, bool aktiveRunde) : base(aktiveRunde) {
            Name = name;
            Score = 0;
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

        public int Score {
            get => _score;
            set {
                if (value < 0) {
                    throw new ArgumentOutOfRangeException("Punktzahl ist kleiner als 0!");
                }
                _score = value;
            }
        }

        /// <summary>
        /// Speichern("Merken") aller aufgedeckten Karten
        /// </summary>
        /// <param name="karte"></param>
        /// <param name="zeile"></param>
        /// <param name="spalte"></param>
        public override void Gedaechtnis(string karte, int zeile, int spalte) {
            base.Gedaechtnis(karte, zeile, spalte);
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
        /// Anschauen einer Karte mit Zeitmessung
        /// </summary>
        /// <param name="stopwatch"></param>
        /// <param name="buttons"></param>
        public override void Karteanschauen(ref Stopwatch stopwatch, Button[] buttons) {
            stopwatch.Start();
        }
    }
}
