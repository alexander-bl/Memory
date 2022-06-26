using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
/*
* Kindklasse von Spieler
* Autoren: Alexander Bletsch, Anna Stork
* Erstellt: 09.06.22
*/

namespace Memory {
    public class Computer : Spieler {
        string _difficulty;//Schwierigkeitsgrad des Computers
        int _anzahlAufgedecktePaare;//Anzahl aller Aufgedeckten Karten paare
        int _anzahlRichtigerPaare;//Anzahl aller richtig aufgedeckten Karten paare

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
            AnzahlAufgedecktePaare = 0;
            AnzahlRichtigerPaare = 0;
        }

        /// <summary>
        /// Speichern("Merken") der Letzen aufgedeckten Karten
        /// </summary>
        /// <param name="karte"></param>
        /// <param name="zeile"></param>
        /// <param name="spalte"></param>
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
        /// Auswahl eines Zufähligen Buttons
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

        //public async void Event(Func<KnownCard, Task> ButtonEvent, KnownCard card) {
        //await ButtonEvent(card);
        //}

        /*/// <summary>
        /// Auswahl welche Karte angeschaut wird
        /// </summary>
        /// <param name="buttons"></param>
        public async void Karteanschauen(ref Button[] buttons, KnownCard card) {
            MainWindow mainWindow = new MainWindow();
            GeseheneKarten.Sort((s1, s2) => s1.Karte.CompareTo(s2.Karte));//Sortiere Karten Liste

            for (int i = 0; i < GeseheneKarten.Count - 1; i++) {

                //Wenn Coumputer noch keine Karte angeschaut hatt entscheidung welche gewählt wird
                if (GeseheneKarten.Count % 2 == 0) {

                    //Alle Karten im Gedächniss durchschauen
                    if (GeseheneKarten[i].Karte == GeseheneKarten[i + 1].Karte) {
                        await mainWindow.ButtonEvent(GeseheneKarten[i]);
                        //Wenn gleiche Karte gefunden dann klicke auf Karte 
                        switch (GeseheneKarten[i].Zeile) {
                            case 1:
                                switch (GeseheneKarten[i].Spalte) {
                                    case 1:
                                        await mainWindow.ButtonEvent(GeseheneKarten[i]);
                                        //buttons[0].RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                                        break;
                                    case 2:
                                        //buttons[1].RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                                        break;
                                    case 3:
                                        buttons[2].RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                                        break;
                                    case 4:
                                        buttons[3].RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                                        break;
                                    default:
                                        break;
                                }
                                break;

                            case 2:
                                switch (GeseheneKarten[i].Spalte) {
                                    case 1:
                                        buttons[4].RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                                        break;
                                    case 2:
                                        buttons[5].RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                                        break;
                                    case 3:
                                        buttons[6].RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                                        break;
                                    case 4:
                                        buttons[7].RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                                        break;
                                    default:
                                        break;
                                }
                                break;

                            case 3:
                                switch (GeseheneKarten[i].Spalte) {
                                    case 1:
                                        buttons[8].RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                                        break;
                                    case 2:
                                        buttons[9].RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                                        break;
                                    case 3:
                                        buttons[10].RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                                        break;
                                    case 4:
                                        buttons[11].RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                                        break;
                                    default:
                                        break;
                                }
                                break;

                            case 4:
                                switch (GeseheneKarten[i].Spalte) {
                                    case 1:
                                        buttons[12].RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                                        break;
                                    case 2:
                                        buttons[13].RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                                        break;
                                    case 3:

                                        buttons[14].RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                                        break;
                                    case 4:

                                        buttons[15].RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                                        break;
                                    default:
                                        break;
                                }
                                break;
                    }
                } else {
                    //Wenn Karte im Gedächnis gleich aktuell gewählte karte, dann überspribge diese
                    if ((GeseheneKarten[i].Zeile == card.Zeile) && (GeseheneKarten[i].Spalte == card.Spalte)) {
                        i++;
                    }
                    if (GeseheneKarten[i].Karte == card.Karte) {
                        await mainWindow.ButtonEvent(GeseheneKarten[i]);
                        //Wenn gleiche Karte gefunden dann klicke auf Karte 
                        switch (GeseheneKarten[i].Zeile) {
                            case 1:
                                switch (GeseheneKarten[i].Spalte) {
                                    case 1:
                                        buttons[0].RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                                        break;
                                    case 2:
                                        buttons[1].RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                                        break;
                                    case 3:
                                        buttons[2].RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                                        break;
                                    case 4:
                                        buttons[3].RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                                        break;
                                    default:
                                        break;
                                }
                                break;

                            case 2:
                                switch (GeseheneKarten[i].Spalte) {
                                    case 1:
                                        buttons[4].RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                                        break;
                                    case 2:
                                        buttons[5].RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                                        break;
                                    case 3:
                                        buttons[6].RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                                        break;
                                    case 4:
                                        buttons[7].RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                                        break;
                                    default:
                                        break;
                                }
                                break;

                            case 3:
                                switch (GeseheneKarten[i].Spalte) {
                                    case 1:
                                        buttons[8].RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                                        break;
                                    case 2:
                                        buttons[9].RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                                        break;
                                    case 3:
                                        buttons[10].RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                                        break;
                                    case 4:
                                        buttons[11].RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                                        break;
                                    default:
                                        break;
                                }
                                break;

                            case 4:
                                switch (GeseheneKarten[i].Spalte) {
                                    case 1:
                                        buttons[12].RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                                        break;
                                    case 2:
                                        buttons[13].RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                                        break;
                                    case 3:

                                        buttons[14].RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                                        break;
                                    case 4:

                                        buttons[15].RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                                        break;
                                    default:
                                        break;
                                }
                                break;
                        }
                    }
                }
            }
            List<Button> buttonslist = new List<Button>(buttons);
            Button button = Random(buttonslist);
            button.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));//Klicke auf Zufällige Karte
        }*/
    }
}

