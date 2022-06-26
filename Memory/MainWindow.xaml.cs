using Serilog;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

        private async void ComputerKarteanschauen(KnownCard card) {
            _computer.GeseheneKarten.Sort((s1, s2) => s1.Karte.CompareTo(s2.Karte));//Sortiere Karten Liste

            for (int i = 0; i < _computer.GeseheneKarten.Count - 1; i++) {

                //Wenn Coumputer noch keine Karte angeschaut hatt entscheidung welche gewählt wird
                if (_computer.GeseheneKarten.Count % 2 == 0) {
                    Log.Warning("stelle 1, " + _computer.GeseheneKarten.Count);
                    //Alle Karten im Gedächniss durchschauen
                    if (_computer.GeseheneKarten[i].Karte == _computer.GeseheneKarten[i + 1].Karte) {
                        //Log.Warning("stelle 2, " + i);
                        await ButtonEvent(_computer.GeseheneKarten[i]);
                        return;
                    }

                } else {
                    Log.Warning("stelle 1.5, " + _computer.GeseheneKarten.Count);
                    //Wenn Karte im Gedächnis gleich aktuell gewählte karte, dann überspribge diese
                    if ((_computer.GeseheneKarten[i].Zeile == card.Zeile) && (_computer.GeseheneKarten[i].Spalte == card.Spalte)) {
                        Log.Warning("stelle 3, " + i);
                        continue;
                    }
                    if (_computer.GeseheneKarten[i].Karte == card.Karte) {
                        Log.Warning("stelle 4, " + i);
                        await ButtonEvent(_computer.GeseheneKarten[i]);
                        return;
                    }
                }
            }
            KnownCard rndCard = _computer.Random(_spielFeld);
            Log.Warning("stelle 5, ");
            await ButtonEvent(rndCard);
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

        private async Task ButtonEvent(KnownCard card) {
            

            ButtonContentShow(card);
            Spieler spieler;

            

            //Setze fest welcher Spieler an der Reihe ist
            if (_mensch.AktiveRunde) {
                spieler = _mensch;
            } else {
                spieler = _computer;
            }

            logcounter++;
            string str = card.Karte.ToString() + ", " + card.Zeile.ToString() + ", " + card.Spalte.ToString() + " # " + spieler.ToString();
            Log.Error(logcounter + str);

            

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
                _mensch.AktiveRunde = !_mensch.AktiveRunde;
                _computer.AktiveRunde = !_mensch.AktiveRunde;

                //Karte ins Gedächnis Speichern
                _mensch.Gedaechtnis(card);
                _computer.Gedaechtnis(card);

                //Offene Karten reseten
                spieler.OffeneKarten = new Tuple<KnownCard, KnownCard>(
                        new KnownCard("", 0, 0), new KnownCard("", 0, 0));
            }

            //Computer entscheidung welche Buttons gedrückt werden
            if (_computer.AktiveRunde) {
                ComputerKarteanschauen(card);
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

            KnownCard[] deaktivierendeKarten = new KnownCard[] { spieler.OffeneKarten.Item1, spieler.OffeneKarten.Item2 };
            foreach (var card in deaktivierendeKarten) {
                //Deaktivieren des korrektem karten paars
                switch (card.Zeile) {
                    case 1:
                        switch (card.Spalte) {
                            case 1:
                                Button.IsEnabled = false;
                                _spielFeld.Feld[0, 0] = "";
                                break;
                            case 2:
                                Button2.IsEnabled = false;
                                _spielFeld.Feld[0, 1] = "";
                                break;
                            case 3:
                                Button3.IsEnabled = false;
                                _spielFeld.Feld[0, 2] = "";
                                break;
                            case 4:
                                Button4.IsEnabled = false;
                                _spielFeld.Feld[0, 3] = "";
                                break;
                            default:
                                break;
                        }
                        break;

                    case 2:
                        switch (card.Spalte) {
                            case 1:
                                Button5.IsEnabled = false;
                                _spielFeld.Feld[1, 0] = "";
                                break;
                            case 2:
                                Button6.IsEnabled = false;
                                _spielFeld.Feld[1, 1] = "";
                                break;
                            case 3:
                                Button7.IsEnabled = false;
                                _spielFeld.Feld[1, 2] = "";
                                break;
                            case 4:
                                Button8.IsEnabled = false;
                                _spielFeld.Feld[1, 3] = "";
                                break;
                            default:
                                break;
                        }
                        break;

                    case 3:
                        switch (card.Spalte) {
                            case 1:
                                Button9.IsEnabled = false;
                                _spielFeld.Feld[2, 0] = "";
                                break;
                            case 2:
                                Button10.IsEnabled = false;
                                _spielFeld.Feld[2, 1] = "";
                                break;
                            case 3:
                                Button11.IsEnabled = false;
                                _spielFeld.Feld[2, 2] = "";
                                break;
                            case 4:
                                Button12.IsEnabled = false;
                                _spielFeld.Feld[2, 3] = "";
                                break;
                            default:
                                break;
                        }
                        break;

                    case 4:
                        switch (card.Spalte) {
                            case 1:
                                Button13.IsEnabled = false;
                                _spielFeld.Feld[3, 0] = "";
                                break;
                            case 2:
                                Button14.IsEnabled = false;
                                _spielFeld.Feld[3, 1] = "";
                                break;
                            case 3:
                                Button15.IsEnabled = false;
                                _spielFeld.Feld[3, 2] = "";
                                break;
                            case 4:
                                Button16.IsEnabled = false;
                                _spielFeld.Feld[3, 3] = "";
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
            Mouse.OverrideCursor = Cursors.Wait;
            await Task.Delay(3000);
            Mouse.OverrideCursor = null;

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

        private void ButtonContentShow(KnownCard card) {
            //Verstecken des karten paars
            switch (card.Zeile) {
                case 1:
                    switch (card.Spalte) {
                        case 1:
                            tBox_Button.Visibility = Visibility.Visible;
                            break;
                        case 2:
                            tBox_Button2.Visibility = Visibility.Visible;
                            break;
                        case 3:
                            tBox_Button3.Visibility = Visibility.Visible;
                            break;
                        case 4:
                            tBox_Button4.Visibility = Visibility.Visible;
                            break;
                        default:
                            break;
                    }
                    break;

                case 2:
                    switch (card.Spalte) {
                        case 1:
                            tBox_Button5.Visibility = Visibility.Visible;
                            break;
                        case 2:
                            tBox_Button6.Visibility = Visibility.Visible;
                            break;
                        case 3:
                            tBox_Button7.Visibility = Visibility.Visible;
                            break;
                        case 4:
                            tBox_Button8.Visibility = Visibility.Visible;
                            break;
                        default:
                            break;
                    }
                    break;

                case 3:
                    switch (card.Spalte) {
                        case 1:
                            tBox_Button9.Visibility = Visibility.Visible;
                            break;
                        case 2:
                            tBox_Button10.Visibility = Visibility.Visible;
                            break;
                        case 3:
                            tBox_Button11.Visibility = Visibility.Visible;
                            break;
                        case 4:
                            tBox_Button12.Visibility = Visibility.Visible;
                            break;
                        default:
                            break;
                    }
                    break;

                case 4:
                    switch (card.Spalte) {
                        case 1:
                            tBox_Button13.Visibility = Visibility.Visible;
                            break;
                        case 2:
                            tBox_Button14.Visibility = Visibility.Visible;
                            break;
                        case 3:
                            tBox_Button15.Visibility = Visibility.Visible;
                            break;
                        case 4:
                            tBox_Button16.Visibility = Visibility.Visible;
                            break;
                        default:
                            break;
                    }
                    break;
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

        private async void MenuItem_Zufall_Click(object sender, RoutedEventArgs e) {
            if (_mensch == null) {
                MessageBox.Show("Es muss ein Spiel aktiv sein," +
                    " um mit dem Spiel interagierende Buttons Drücken zu können!", "Fehler");
                return;
            }

            KnownCard card = _mensch.Random(_spielFeld);
            await ButtonEvent(card);
        }



        /*
         * 
         * Button Events
         * 
         */
        private async void Button_Click(object sender, RoutedEventArgs e) {
            KnownCard card = new KnownCard(tBox_Button.Text, 1, 1);//Karte des Buttons
            await ButtonEvent(card);
        }//Button 1

        private async void Button_Click_2(object sender, RoutedEventArgs e) {
            KnownCard card = new KnownCard(tBox_Button2.Text, 1, 2);//Karte des Buttons
            await ButtonEvent(card);
        }//Button 2

        private async void Button_Click_3(object sender, RoutedEventArgs e) {
            KnownCard card = new KnownCard(tBox_Button3.Text, 1, 3);//Karte des Buttons
            await ButtonEvent(card);
        }//Button 3

        private async void Button_Click_4(object sender, RoutedEventArgs e) {
            KnownCard card = new KnownCard(tBox_Button4.Text, 1, 4);//Karte des Buttons
            await ButtonEvent(card);
        }//Button 4

        private async void Button_Click_5(object sender, RoutedEventArgs e) {
            KnownCard card = new KnownCard(tBox_Button5.Text, 2, 1);//Karte des Buttons
            await ButtonEvent(card);
        }//Button 5

        private async void Button_Click_6(object sender, RoutedEventArgs e) {
            KnownCard card = new KnownCard(tBox_Button6.Text, 2, 2);//Karte des Buttons
            await ButtonEvent(card);
        }//Button 6

        private async void Button_Click_7(object sender, RoutedEventArgs e) {
            KnownCard card = new KnownCard(tBox_Button7.Text, 2, 3);//Karte des Buttons
            await ButtonEvent(card);
        }//Button 7

        private async void Button_Click_8(object sender, RoutedEventArgs e) {
            KnownCard card = new KnownCard(tBox_Button8.Text, 2, 4);//Karte des Buttons
            await ButtonEvent(card);
        }//Button 8

        private async void Button_Click_9(object sender, RoutedEventArgs e) {
            KnownCard card = new KnownCard(tBox_Button9.Text, 3, 1);//Karte des Buttons
            await ButtonEvent(card);
        }//Button 9

        private async void Button_Click_10(object sender, RoutedEventArgs e) {
            KnownCard card = new KnownCard(tBox_Button10.Text, 3, 2);//Karte des Buttons
            await ButtonEvent(card);
        }//Button 10

        private async void Button_Click_11(object sender, RoutedEventArgs e) {
            KnownCard card = new KnownCard(tBox_Button11.Text, 3, 3);//Karte des Buttons
            await ButtonEvent(card);
        }//Button 11

        private async void Button_Click_12(object sender, RoutedEventArgs e) {
            KnownCard card = new KnownCard(tBox_Button12.Text, 3, 4);//Karte des Buttons
            await ButtonEvent(card);
        }//Button 12

        private async void Button_Click_13(object sender, RoutedEventArgs e) {
            KnownCard card = new KnownCard(tBox_Button13.Text, 4, 1);//Karte des Buttons
            await ButtonEvent(card);
        }//Button 13

        private async void Button_Click_14(object sender, RoutedEventArgs e) {
            KnownCard card = new KnownCard(tBox_Button14.Text, 4, 2);//Karte des Buttons
            await ButtonEvent(card);
        }//Button 14

        private async void Button_Click_15(object sender, RoutedEventArgs e) {
            KnownCard card = new KnownCard(tBox_Button15.Text, 4, 3);//Karte des Buttons
            await ButtonEvent(card);
        }//Button 15

        private async void Button_Click_16(object sender, RoutedEventArgs e) {
            KnownCard card = new KnownCard(tBox_Button16.Text, 4, 4);//Karte des Buttons
            await ButtonEvent(card);
        }//Button 16

    }//MainWondow class
}//namespace Memory
