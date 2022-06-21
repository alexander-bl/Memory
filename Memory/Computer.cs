using System.Windows;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Threading;
using System.Threading.Tasks;
/*
 * Kindklasse von Spieler
 * Autoren: Alexander Bletsch, Anna Stork
 * Erstellt: 09.06.22
 */

namespace Memory {
    public class Computer : Spieler {
        string _difficulty;
        int _anzahlAufgedecktePaare;
        int _anzahlRichtigerPaare;

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
                if (value<0) {
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
        public override void Gedaechtnis(string karte, int zeile, int spalte) {
            base.Gedaechtnis(karte, zeile, spalte);
            int maxGedaechnisGroesse;
            switch (Difficulty) {
                case "Normal":
                    maxGedaechnisGroesse = 5;
                    break;

                case "Schwer":
                    maxGedaechnisGroesse = 7;
                    break;

                default:
                    maxGedaechnisGroesse = 5;
                    break;
            }
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
        /// Anschauen einer Karte
        /// </summary>
        /// <param name="stopwatch"></param>
        /// <param name="buttons"></param>
        public override void Karteanschauen(ref Stopwatch stopwatch, Button[] buttons) {
            GeseheneKarten.Sort((s1, s2) => s1.Karte.CompareTo(s2.Karte));//Sortiere Karten Liste

            for (int i = 0; i < GeseheneKarten.Count; i++) {
                //Alle Karten im Gedächniss durchschauen
                if (GeseheneKarten[i].Karte == GeseheneKarten[i + 1].Karte) {
                    //Wenn gleiche Karte gefunden dann klicke auf Karte 
                    switch (GeseheneKarten[i].Zeile) {
                        case 1:
                            switch (GeseheneKarten[i].Spalte) {
                                case 1:
                                    buttons[0].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                    break;
                                case 2:
                                    buttons[1].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                    break;
                                case 3:
                                    buttons[2].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                    break;
                                case 4:
                                    buttons[3].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                    break;
                                default:
                                    break;
                            }
                            break;

                        case 2:
                            switch (GeseheneKarten[i].Spalte) {
                                case 1:
                                    buttons[4].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                    break;
                                case 2:
                                    buttons[5].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                    break;
                                case 3:
                                    buttons[6].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                    break;
                                case 4:
                                    buttons[7].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                    break;
                                default:
                                    break;
                            }
                            break;

                        case 3:
                            switch (GeseheneKarten[i].Spalte) {
                                case 1:
                                    buttons[8].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                    break;
                                case 2:
                                    buttons[9].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                    break;
                                case 3:
                                    buttons[10].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                    break;
                                case 4:
                                    buttons[11].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                    break;
                                default:
                                    break;
                            }
                            break;

                        case 4:
                            switch (GeseheneKarten[i].Spalte) {
                                case 1:
                                    buttons[12].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                    break;
                                case 2:
                                    buttons[13].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                    break;
                                case 3:
                                    buttons[14].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                    break;
                                case 4:
                                    buttons[15].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                    break;
                                default:
                                    break;
                            }
                            break;
                    }


                    switch (GeseheneKarten[i + 1].Zeile) {
                        case 1:
                            switch (GeseheneKarten[i + 1].Spalte) {
                                case 1:
                                    buttons[0].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                    break;
                                case 2:
                                    buttons[1].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                    break;
                                case 3:
                                    buttons[2].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                    break;
                                case 4:
                                    buttons[3].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                    break;
                                default:
                                    break;
                            }
                            break;

                        case 2:
                            switch (GeseheneKarten[i + 1].Spalte) {
                                case 1:
                                    buttons[4].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                    break;
                                case 2:
                                    buttons[5].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                    break;
                                case 3:
                                    buttons[6].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                    break;
                                case 4:
                                    buttons[7].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                    break;
                                default:
                                    break;
                            }
                            break;

                        case 3:
                            switch (GeseheneKarten[i + 1].Spalte) {
                                case 1:
                                    buttons[8].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                    break;
                                case 2:
                                    buttons[9].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                    break;
                                case 3:
                                    buttons[10].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                    break;
                                case 4:
                                    buttons[11].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                    break;
                                default:
                                    break;
                            }
                            break;

                        case 4:
                            switch (GeseheneKarten[i + 1].Spalte) {
                                case 1:
                                    buttons[12].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                    break;
                                case 2:
                                    buttons[13].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                    break;
                                case 3:
                                    buttons[14].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                    break;
                                case 4:
                                    buttons[15].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                    break;
                                default:
                                    break;
                            }
                            break;
                    }
                    return;
                }
                
            }
                List<Button> buttonslist = new List<Button>(buttons);
                Button button = Random(buttonslist);
                button.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));//Klicke auf Zufällige Karte

                Thread.Sleep(2000);

                for (int i = 0; i < GeseheneKarten.Count; i++) {
                    if (GeseheneKarten[i].Karte == (string)button.Content) {
                    //Wenn Karte gleich einer Karte im Gedächniss, klicke sie
                        switch (GeseheneKarten[i].Zeile) {
                            case 1:
                                switch (GeseheneKarten[i].Spalte) {
                                    case 1:
                                        buttons[0].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                        break;
                                    case 2:
                                        buttons[1].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                        break;
                                    case 3:
                                        buttons[2].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                        break;
                                    case 4:
                                        buttons[3].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                        break;
                                    default:
                                        break;
                                }
                                break;

                            case 2:
                                switch (GeseheneKarten[i].Spalte) {
                                    case 1:
                                        buttons[4].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                        break;
                                    case 2:
                                        buttons[5].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                        break;
                                    case 3:
                                        buttons[6].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                        break;
                                    case 4:
                                        buttons[7].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                        break;
                                    default:
                                        break;
                                }
                                break;

                            case 3:
                                switch (GeseheneKarten[i].Spalte) {
                                    case 1:
                                        buttons[8].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                        break;
                                    case 2:
                                        buttons[9].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                        break;
                                    case 3:
                                        buttons[10].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                        break;
                                    case 4:
                                        buttons[11].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                        break;
                                    default:
                                        break;
                                }
                                break;

                            case 4:
                                switch (GeseheneKarten[i].Spalte) {
                                    case 1:
                                        buttons[12].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                        break;
                                    case 2:
                                        buttons[13].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                        break;
                                    case 3:
                                        buttons[14].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                        break;
                                    case 4:
                                        buttons[15].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                        break;
                                    default:
                                        break;
                                }
                                break;
                        }
                        Task.WaitAll(new Task[] { Task.Delay(2000) });
                        return;
                    }
                }
            button = Random(buttonslist);
            button.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));//Klicke 2te Zufällige Karte
        }
    }
}
