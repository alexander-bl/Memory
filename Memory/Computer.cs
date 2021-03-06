using System;
using System.Collections.Generic;
/*
* Kindklasse von Spieler
* Autoren: Alexander Bletsch, Anna Stork
* Erstellt: 09.06.22
*/

namespace Memory {
    public class Computer : Spieler {
        string _difficulty;//Schwierigkeitsgrad des Computers
        int _anzahlRichtigerPaare;//Anzahl aller richtig aufgedeckten Karten paare
        int _anzahlAufgedecktePaare;//Anzahl aller vom Computer Aufgedeckten Karten paare

        public string Difficulty {
            get => _difficulty;
            set {
                if (value == "Normal" || value == "Schwer") {
                    _difficulty = value ?? throw new ArgumentNullException(
                                                "Kein Schwierigkeitsgrad vorhanden!");
                } else {
                    throw new ArgumentException(
                        "Schwierigkeitsgrad ist nicht Normal oder Schwer!");
                }
            }
        }

        public int AnzahlAufgedecktePaare {
            get => _anzahlAufgedecktePaare;
            set {
                if (value < 0) {
                    throw new ArgumentOutOfRangeException(
                        "Anzahl Aufgedeckter Paare ist kleiner 0!");
                }
                _anzahlAufgedecktePaare = value;
            }
        }

        public int AnzahlRichtigerPaare {
            get => _anzahlRichtigerPaare;
            set {
                if (value < 0) {
                    throw new ArgumentOutOfRangeException(
                            "Anzahl Richtiger Paare vom Computer ist kleiner als 0!");
                }
                _anzahlRichtigerPaare = value;
            }
        }

        

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="difficulty"></param>
        /// <param name="aktiveRunde"></param>
        public Computer(string difficulty, bool aktiveRunde) : base(aktiveRunde) {
            Difficulty = difficulty;
            AnzahlRichtigerPaare = 0;
            AnzahlAufgedecktePaare = 0;
        }

        public Computer(string difficulty, int anzahlAufgedecktePaare,
                        int anzahlRichtigerPaare, bool aktiveRunde)
                        :base(aktiveRunde){

            Difficulty = difficulty;
            AnzahlAufgedecktePaare = anzahlAufgedecktePaare;
            AnzahlRichtigerPaare = anzahlRichtigerPaare;
        }



        /// <summary>
        /// Speichern("Merken") der Letzen aufgedeckten Karten
        /// </summary>
        /// <param name="card"></param>
        public override void Gedaechtnis(KnownCard card) {
            base.Gedaechtnis(card);//Speicher Karte ins Gedächniss
            int maxGedaechnisGroesse;
            //Überprüfen der maxGröße vom Gedächniss
            switch (Difficulty) {
                case "Normal":
                    maxGedaechnisGroesse = 4;
                    break;

                case "Schwer":
                    maxGedaechnisGroesse = 6;
                    break;

                default:
                    maxGedaechnisGroesse = 4;
                    break;
            }
            //Wenn Gedächniss größer als maxGedächnis Größe dann ist, lösche älteste Elememte
            while (GeseheneKarten.Count > maxGedaechnisGroesse) {
                GeseheneKarten.RemoveAt(0);
                GeseheneKarten.TrimExcess();
            }
        }

        /// <summary>
        /// Zufällige Karte auswählen
        /// </summary>
        /// <param name="rnd"></param>
        /// <param name="aktcard"></param>
        /// <returns></returns>
        public override KnownCard Random(Random rnd, KnownCard aktcard) {
            KnownCard card = base.Random(rnd, aktcard);

            return card;
        }

        /// <summary>
        /// Handled die Offenen Karten des aktuell Spielenden Computers
        /// </summary>
        /// <param name="card"></param>
        /// <returns>Ist Zweite Karte aufgedeckt?</returns>
        public override bool OffeneKartenHandler(KnownCard card) {
            //Test ob Aufgedeckte Karte erste oder zweite Karte ist
            if (OffeneKarten.Item1.Karte == "") {
                KnownCard emptyCard = new KnownCard("", 0, 0);
                OffeneKarten = new Tuple<KnownCard, KnownCard>(card, emptyCard);
                return false;//false weil aufgedeckte Karte die erste Karte der Runde ist
            } else {
                OffeneKarten = new Tuple<KnownCard, KnownCard>(OffeneKarten.Item1, card);
                return true;//true weil aufgedeckte Karte die zweite Karte der Runde ist
            }
        }
    }
}

