using System.Windows;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows.Input;
using Serilog;

namespace Memory {
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        int logcounter = 0;
        Mensch _mensch = null;
        Computer _computer = null;
        Button[] _buttons = null;
        SpielFeld _spielFeld = null;
        public MainWindow() {
            InitializeComponent();

            Log.Logger = new LoggerConfiguration()
                            .WriteTo.File(@"C:\Temp\Log.txt", outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                            .CreateLogger();

            _buttons = new Button[]{Button, Button2, Button3, Button4, Button4, Button5,
                                Button6, Button7, Button8, Button9, Button10, Button11,
                                Button12, Button13, Button14, Button15, Button16};
            IsAllButtonsEnabled(false);
        }

        private void IsAllButtonsEnabled(bool isEnabled) {
            Button.IsEnabled = isEnabled;
            Button2.IsEnabled = isEnabled;
            Button3.IsEnabled = isEnabled;
            Button4.IsEnabled = isEnabled;
            Button5.IsEnabled = isEnabled;
            Button6.IsEnabled = isEnabled;
            Button7.IsEnabled = isEnabled;
            Button8.IsEnabled = isEnabled;
            Button9.IsEnabled = isEnabled;
            Button10.IsEnabled = isEnabled;
            Button11.IsEnabled = isEnabled;
            Button12.IsEnabled = isEnabled;
            Button13.IsEnabled = isEnabled;
            Button14.IsEnabled = isEnabled;
            Button15.IsEnabled = isEnabled;
            Button16.IsEnabled = isEnabled;
        }

        public async Task ButtonEvent(KnownCard card) {
            logcounter++;
            Log.Error(logcounter.ToString());
            Spieler spieler;

            //Setze fest welcher Spieler an der Reihe ist
            if (_mensch.AktiveRunde) {
                spieler = _mensch;
            } else {
                spieler = _computer;
            }

            //Karte ins Gedächnis Speichern
            _mensch.Gedaechtnis(card);
            _computer.Gedaechtnis(card);

            if (spieler.OffeneKartenHandler(card)) {//Funktonsaufruf zum umgang mit aufgedeckten Karten

                //Kartenvergleichen
                if (await KartenVergleich(spieler.OffeneKarten.Item1, spieler.OffeneKarten.Item2)) {

                    spieler.AnzahlGefundenerPaare++;

                    //Punkte für richtiges paar für Mensch 
                    if (_mensch.AktiveRunde) {
                        int newscore = (1 / ((int)_mensch.Stopwatch.Elapsed.TotalMilliseconds)) * 1000;
                        _mensch.Score += newscore;
                        tBoxPunkte.Text = _mensch.Score.ToString();
                    } else {

                        //Punkte für richtiges paar für Computer
                        _computer.AnzahlAufgedecktePaare++;
                        _computer.AnzahlRichtigerPaare++;
                    }

                    //Richtiges Kartenpaar vom Gedächnis und vom Spielfeld entfernen
                    GedaechnisLoeschen(_mensch, _computer, spieler.OffeneKarten.Item1, spieler.OffeneKarten.Item2);
                    ButtonDeaktivieren(spieler);

                    //Wenn Karten paar nicht korrekt, dann zähler computer erhöhen
                } else if (_computer.AktiveRunde) {
                    _computer.AnzahlAufgedecktePaare++;
                }

                ButtonContentHide(spieler);//Button Content Nicht Sichtbar machen nachdem Paar kontrolliert wurde
                //Spiel Beenden wenn alle Karten paare gefunden sind
                if (_mensch.AnzahlGefundenerPaare + _computer.AnzahlGefundenerPaare == 8) {
                    SpielBeenden();
                    return;
                }

                //Wechseln wer an der Reihe ist
                if (_mensch.AktiveRunde) {
                    _mensch.AktiveRunde = false;
                    _computer.AktiveRunde = true;
                } else {
                    _mensch.AktiveRunde = true;
                    _computer.AktiveRunde = false;
                }
                //_mensch.AktiveRunde = !_mensch.AktiveRunde;
                //_computer.AktiveRunde = !_mensch.AktiveRunde;

                //Offene Karten reseten
                spieler.OffeneKarten = new Tuple<KnownCard, KnownCard>(
                        new KnownCard("", 0, 0), new KnownCard("", 0, 0));
            }

            //Computer entscheidung welche Buttons gedrückt werden
            if (_computer.AktiveRunde) {
                _computer.Karteanschauen(/*ref _buttons,*/ card);
            }
        }

        private void SpielBeenden() {
            
        }

        private void GedaechnisLoeschen(Spieler spieler1, Spieler spieler2, 
                                        KnownCard karte1, KnownCard karte2) {
            while (spieler1.GeseheneKarten.Contains(karte1)) {
                spieler1.GeseheneKarten.Remove(karte1);
            }
            while (spieler1.GeseheneKarten.Contains(karte2)) {
                spieler1.GeseheneKarten.Remove(karte2);
            }

            while (spieler2.GeseheneKarten.Contains(karte1)) {
                spieler2.GeseheneKarten.Remove(karte1);
            }
            while (spieler2.GeseheneKarten.Remove(karte2)) {
                spieler2.GeseheneKarten.Remove(karte2);
            }

            spieler1.GeseheneKarten.TrimExcess();
            spieler2.GeseheneKarten.TrimExcess();
        }

        private void ButtonDeaktivieren(Spieler spieler) {

            KnownCard[] deaktivierendeKarten = new KnownCard[] {spieler.OffeneKarten.Item1, spieler.OffeneKarten.Item2};
            foreach (var card in deaktivierendeKarten) {
                //Deaktivieren des korrektem karten paars
                switch (card.Zeile) {
                    case 1:
                        switch (card.Spalte) {
                            case 1:
                                Button.IsEnabled = false;
                                break;
                            case 2:
                                Button2.IsEnabled = false;
                                break;
                            case 3:
                                Button3.IsEnabled = false;
                                break;
                            case 4:
                                Button4.IsEnabled = false;
                                break;
                            default:
                                break;
                        }
                        break;

                    case 2:
                        switch (card.Spalte) {
                            case 1:
                                Button5.IsEnabled = false;
                                break;
                            case 2:
                                Button6.IsEnabled = false;
                                break;
                            case 3:
                                Button7.IsEnabled = false;
                                break;
                            case 4:
                                Button8.IsEnabled = false;
                                break;
                            default:
                                break;
                        }
                        break;

                    case 3:
                        switch (card.Spalte) {
                            case 1:
                                Button9.IsEnabled = false;
                                break;
                            case 2:
                                Button10.IsEnabled = false;
                                break;
                            case 3:
                                Button11.IsEnabled = false;
                                break;
                            case 4:
                                Button12.IsEnabled = false;
                                break;
                            default:
                                break;
                        }
                        break;

                    case 4:
                        switch (card.Spalte) {
                            case 1:
                                Button13.IsEnabled = false;
                                break;
                            case 2:
                                Button14.IsEnabled = false;
                                break;
                            case 3:
                                Button15.IsEnabled = false;
                                break;
                            case 4:
                                Button16.IsEnabled = false;
                                break;
                            default:
                                break;
                        }
                        break;
                }
            }
        }

        private async Task<bool> KartenVergleich(KnownCard karte1, KnownCard karte2) {
            //Maus cursor auf warten symbol setzen und warten damit Spieler sich die Karten anschauen kann
            //IsAllButtonsEnabled(false);
            Mouse.OverrideCursor = Cursors.Wait;
            await Task.Delay(3000);
            Mouse.OverrideCursor = null;
            //IsAllButtonsEnabled(true);

            //Kontrolle ob Karten paar gleich ist
            bool istGleicheKarte = false;
            if (karte1.Karte == karte2.Karte) {
                istGleicheKarte = true;
            }

            return istGleicheKarte;
        }

        private void ButtonContentHide(Spieler spieler) {
            KnownCard[] versteckendeKarten = new KnownCard[] { spieler.OffeneKarten.Item1, spieler.OffeneKarten.Item2 };
            foreach (var card in versteckendeKarten) {
                //Verstecken des karten paars
                switch (card.Zeile) {
                    case 1:
                        switch (card.Spalte) {
                            case 1:
                                tBox_Button.Visibility = Visibility.Hidden;
                                break;
                            case 2:
                                tBox_Button2.Visibility = Visibility.Hidden;
                                break;
                            case 3:
                                tBox_Button3.Visibility = Visibility.Hidden;
                                break;
                            case 4:
                                tBox_Button4.Visibility = Visibility.Hidden;
                                break;
                            default:
                                break;
                        }
                        break;

                    case 2:
                        switch (card.Spalte) {
                            case 1:
                                tBox_Button5.Visibility = Visibility.Hidden;
                                break;
                            case 2:
                                tBox_Button6.Visibility = Visibility.Hidden;
                                break;
                            case 3:
                                tBox_Button7.Visibility = Visibility.Hidden;
                                break;
                            case 4:
                                tBox_Button8.Visibility = Visibility.Hidden;
                                break;
                            default:
                                break;
                        }
                        break;

                    case 3:
                        switch (card.Spalte) {
                            case 1:
                                tBox_Button9.Visibility = Visibility.Hidden;
                                break;
                            case 2:
                                tBox_Button10.Visibility = Visibility.Hidden;
                                break;
                            case 3:
                                tBox_Button11.Visibility = Visibility.Hidden; ;
                                break;
                            case 4:
                                tBox_Button12.Visibility = Visibility.Hidden;
                                break;
                            default:
                                break;
                        }
                        break;

                    case 4:
                        switch (card.Spalte) {
                            case 1:
                                tBox_Button13.Visibility = Visibility.Hidden;
                                break;
                            case 2:
                                tBox_Button14.Visibility = Visibility.Hidden;
                                break;
                            case 3:
                                tBox_Button15.Visibility = Visibility.Hidden;
                                break;
                            case 4:
                                tBox_Button16.Visibility = Visibility.Hidden;
                                break;
                            default:
                                break;
                        }
                        break;
                }
            }
        }

        private void MenuItem_NeuesSpiel_Click(object sender, RoutedEventArgs e) {
            //Neues Dialog Fenster für neues Spiel erstellen Starten
            Neues_Spiel_Fenster neuesSpielFenster = new Neues_Spiel_Fenster();
            bool? ok = neuesSpielFenster.ShowDialog();

            if ((bool)ok) {//Erstellen aller Spielnotwendigen Objekte
                _spielFeld = neuesSpielFenster.SpielFeld;
                _mensch = neuesSpielFenster.Mensch;
                _computer = neuesSpielFenster.Computer;
            } else {
                return;
            }

            //Setzen von Spielanzeigen
            tBoxName.Text = _mensch.Name;
            tBoxPunkte.Text = _mensch.Score.ToString();
            tBoxSchwierigkeit.Text = _computer.Difficulty;

            //Buttons aktivieren
            IsAllButtonsEnabled(true);

            tBox_Button.Text = _spielFeld.Feld[0, 0];
            tBox_Button2.Text = _spielFeld.Feld[0, 1];
            tBox_Button3.Text = _spielFeld.Feld[0, 2];
            tBox_Button4.Text = _spielFeld.Feld[0, 3];
            tBox_Button5.Text = _spielFeld.Feld[1, 0];
            tBox_Button6.Text = _spielFeld.Feld[1, 1];
            tBox_Button7.Text = _spielFeld.Feld[1, 2];
            tBox_Button8.Text = _spielFeld.Feld[1, 3];
            tBox_Button9.Text = _spielFeld.Feld[2, 0];
            tBox_Button10.Text = _spielFeld.Feld[2, 1];
            tBox_Button11.Text = _spielFeld.Feld[2, 2];
            tBox_Button12.Text = _spielFeld.Feld[2, 3];
            tBox_Button13.Text = _spielFeld.Feld[3, 0];
            tBox_Button14.Text = _spielFeld.Feld[3, 1];
            tBox_Button15.Text = _spielFeld.Feld[3, 2];
            tBox_Button16.Text = _spielFeld.Feld[3, 3];
        }

        private void MenuItem_Highscore_Click(object sender, RoutedEventArgs e) {
            Highscore_Fenster highscoreFenster = new Highscore_Fenster();
            highscoreFenster.ShowDialog();
        }

        private void MenuItem_Hilfe_Click(object sender, RoutedEventArgs e) {

        }

        private void MenuItem_Hinweis_Click(object sender, RoutedEventArgs e) {
            if (_mensch == null) {
                MessageBox.Show(
                    "Es muss ein Spiel aktiv sein, " +
                    "um mit dem Spiel interagierende Buttons Drücken zu können!", "Fehler");
                return;
            }

        }

        private void MenuItem_Zufall_Click(object sender, RoutedEventArgs e) {
            if (_mensch == null) {
                MessageBox.Show("Es muss ein Spiel aktiv sein," +
                    " um mit dem Spiel interagierende Buttons Drücken zu können!", "Fehler");
                return;
            }

            Button button;

            do {
                List<Button> buttonList = new List<Button>(_buttons);
                button = _mensch.Random(buttonList);
            } while (!button.IsEnabled);

            button.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }



        /*
         * 
         * Button Events
         * 
         */
        private async void Button_Click(object sender, RoutedEventArgs e) {
            KnownCard card = new KnownCard(tBox_Button.Text, 1, 1);//Karte des Buttons
            tBox_Button.Visibility = Visibility.Visible;
            await ButtonEvent(card);
        }//Button 1

        private async void Button_Click_2(object sender, RoutedEventArgs e) {
            KnownCard card = new KnownCard(tBox_Button2.Text, 1, 2);//Karte des Buttons
            tBox_Button2.Visibility = Visibility.Visible;
            await ButtonEvent(card);
        }//Button 2

        private async void Button_Click_3(object sender, RoutedEventArgs e) {
            KnownCard card = new KnownCard(tBox_Button3.Text, 1, 3);//Karte des Buttons
            tBox_Button3.Visibility = Visibility.Visible;
            await ButtonEvent(card);
        }//Button 3

        private async void Button_Click_4(object sender, RoutedEventArgs e) {
            KnownCard card = new KnownCard(tBox_Button4.Text, 1, 4);//Karte des Buttons
            tBox_Button4.Visibility = Visibility.Visible;
            await ButtonEvent(card);
        }//Button 4

        private async void Button_Click_5(object sender, RoutedEventArgs e) {
            KnownCard card = new KnownCard(tBox_Button5.Text, 2, 1);//Karte des Buttons
            tBox_Button5.Visibility = Visibility.Visible;
            await ButtonEvent(card);
        }//Button 5

        private async void Button_Click_6(object sender, RoutedEventArgs e) {
            KnownCard card = new KnownCard(tBox_Button6.Text, 2, 2);//Karte des Buttons
            tBox_Button6.Visibility = Visibility.Visible;
            await ButtonEvent(card);
        }//Button 6

        private async void Button_Click_7(object sender, RoutedEventArgs e) {
            KnownCard card = new KnownCard(tBox_Button7.Text, 2, 3);//Karte des Buttons
            tBox_Button7.Visibility = Visibility.Visible;
            await ButtonEvent(card);
        }//Button 7

        private async void Button_Click_8(object sender, RoutedEventArgs e) {
            KnownCard card = new KnownCard(tBox_Button8.Text, 2, 4);//Karte des Buttons
            tBox_Button8.Visibility = Visibility.Visible;
            await ButtonEvent(card);
        }//Button 8

        private async void Button_Click_9(object sender, RoutedEventArgs e) {
            KnownCard card = new KnownCard(tBox_Button9.Text, 3, 1);//Karte des Buttons
            tBox_Button9.Visibility = Visibility.Visible;
            await ButtonEvent(card);
        }//Button 9

        private async void Button_Click_10(object sender, RoutedEventArgs e) {
            KnownCard card = new KnownCard(tBox_Button10.Text, 3, 2);//Karte des Buttons
            tBox_Button10.Visibility = Visibility.Visible;
            await ButtonEvent(card);
        }//Button 10

        private async void Button_Click_11(object sender, RoutedEventArgs e) {
            KnownCard card = new KnownCard(tBox_Button11.Text, 3, 3);//Karte des Buttons
            tBox_Button11.Visibility = Visibility.Visible;
            await ButtonEvent(card);
        }//Button 11

        private async void Button_Click_12(object sender, RoutedEventArgs e) {
            KnownCard card = new KnownCard(tBox_Button12.Text, 3, 4);//Karte des Buttons
            tBox_Button12.Visibility = Visibility.Visible;
            await ButtonEvent(card);
        }//Button 12

        private async void Button_Click_13(object sender, RoutedEventArgs e) {
            KnownCard card = new KnownCard(tBox_Button13.Text, 4, 1);//Karte des Buttons
            tBox_Button13.Visibility = Visibility.Visible;
            await ButtonEvent(card);
        }//Button 13

        private async void Button_Click_14(object sender, RoutedEventArgs e) {
            KnownCard card = new KnownCard(tBox_Button14.Text, 4, 2);//Karte des Buttons
            tBox_Button14.Visibility = Visibility.Visible;
            await ButtonEvent(card);
        }//Button 14

        private async void Button_Click_15(object sender, RoutedEventArgs e) {
            KnownCard card = new KnownCard(tBox_Button15.Text, 4, 3);//Karte des Buttons
            tBox_Button15.Visibility = Visibility.Visible;
            await ButtonEvent(card);
        }//Button 15

        private async void Button_Click_16(object sender, RoutedEventArgs e) {
            KnownCard card = new KnownCard(tBox_Button16.Text, 4, 4);//Karte des Buttons
            tBox_Button16.Visibility = Visibility.Visible;
            await ButtonEvent(card);
        }//Button 16

    }//MainWondow class
}//namespace Memory
