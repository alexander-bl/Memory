using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Memory {
    /// <summary>
    /// Interaktionslogik für Highscore_Fenster.xaml
    /// </summary>
    public partial class Highscore_Fenster : Window {

        public Highscore_Fenster() {
            InitializeComponent();

            Highscore.Datensatz[] zeile;
            if (Highscore.ReadFromFile() == null && Highscore.ReadFromFileSchwer() == null) {
                MessageBox.Show("Keine Highscore-Daten vorhanden!");
            }

            if (Highscore.ReadFromFile() != null) {

                zeile = Highscore.ReadFromFile();
                if (zeile.Length > 1) {
                    tBox1Name.Text = zeile[0].Name;
                    tBox1Punkte.Text = zeile[0].Punkte.ToString();
                    tBox1Computer.Text = zeile[0].Computer.ToString();
                }
                if (zeile.Length > 2) {

                    tBox2Name.Text = zeile[1].Name;
                    tBox2Punkte.Text = zeile[1].Punkte.ToString();
                    tBox2Computer.Text = zeile[1].Computer.ToString();
                }
                if (zeile.Length > 3) {
                    tBox3Name.Text = zeile[2].Name;
                    tBox3Punkte.Text = zeile[2].Punkte.ToString();
                    tBox3Computer.Text = zeile[2].Computer.ToString();
                }
                if (zeile.Length > 4) {
                    tBox4Name.Text = zeile[3].Name;
                    tBox4Punkte.Text = zeile[3].Punkte.ToString();
                    tBox4Computer.Text = zeile[3].Computer.ToString();
                }
                if (zeile.Length > 5) {
                    tBox5Name.Text = zeile[4].Name;
                    tBox5Punkte.Text = zeile[4].Punkte.ToString();
                    tBox5Computer.Text = zeile[4].Computer.ToString();
                }
                if (zeile.Length > 6) {
                    tBox6Name.Text = zeile[5].Name;
                    tBox6Punkte.Text = zeile[5].Punkte.ToString();
                    tBox6Computer.Text = zeile[5].Computer.ToString();
                }
                if (zeile.Length > 7) {
                    tBox7Name.Text = zeile[6].Name;
                    tBox7Punkte.Text = zeile[6].Punkte.ToString();
                    tBox7Computer.Text = zeile[6].Computer.ToString();
                }
                if (zeile.Length > 8) {
                    tBox8Name.Text = zeile[7].Name;
                    tBox8Punkte.Text = zeile[7].Punkte.ToString();
                    tBox8Computer.Text = zeile[7].Computer.ToString();
                }
                if (zeile.Length > 9) {
                    tBox9Name.Text = zeile[8].Name;
                    tBox9Punkte.Text = zeile[8].Punkte.ToString();
                    tBox9Computer.Text = zeile[8].Computer.ToString();
                }
                if (zeile.Length > 10) {
                    tBox10Name.Text = zeile[9].Name;
                    tBox10Punkte.Text = zeile[9].Punkte.ToString();
                    tBox10Computer.Text = zeile[9].Computer.ToString();
                }
            }

            if (Highscore.ReadFromFileSchwer() != null) {
                zeile = Highscore.ReadFromFileSchwer();
                if (zeile.Length > 1) {
                    tBox1Names.Text = zeile[0].Name;
                    tBox1Punktes.Text = zeile[0].Punkte.ToString();
                    tBox1Computers.Text = zeile[0].Computer.ToString();
                }
                if (zeile.Length > 2) {

                    tBox2Names.Text = zeile[1].Name;
                    tBox2Punktes.Text = zeile[1].Punkte.ToString();
                    tBox2Computers.Text = zeile[1].Computer.ToString();
                }
                if (zeile.Length > 3) {
                    tBox3Names.Text = zeile[2].Name;
                    tBox3Punktes.Text = zeile[2].Punkte.ToString();
                    tBox3Computers.Text = zeile[2].Computer.ToString();
                }
                if (zeile.Length > 4) {
                    tBox4Names.Text = zeile[3].Name;
                    tBox4Punktes.Text = zeile[3].Punkte.ToString();
                    tBox4Computers.Text = zeile[3].Computer.ToString();
                }
                if (zeile.Length > 5) {
                    tBox5Names.Text = zeile[4].Name;
                    tBox5Punktes.Text = zeile[4].Punkte.ToString();
                    tBox5Computers.Text = zeile[4].Computer.ToString();
                }
                if (zeile.Length > 6) {
                    tBox6Names.Text = zeile[5].Name;
                    tBox6Punktes.Text = zeile[5].Punkte.ToString();
                    tBox6Computers.Text = zeile[5].Computer.ToString();
                }
                if (zeile.Length > 7) {
                    tBox7Names.Text = zeile[6].Name;
                    tBox7Punktes.Text = zeile[6].Punkte.ToString();
                    tBox7Computers.Text = zeile[6].Computer.ToString();
                }
                if (zeile.Length > 8) {
                    tBox8Names.Text = zeile[7].Name;
                    tBox8Punktes.Text = zeile[7].Punkte.ToString();
                    tBox8Computers.Text = zeile[7].Computer.ToString();
                }
                if (zeile.Length > 9) {
                    tBox9Names.Text = zeile[8].Name;
                    tBox9Punktes.Text = zeile[8].Punkte.ToString();
                    tBox9Computers.Text = zeile[8].Computer.ToString();
                }
                if (zeile.Length > 10) {
                    tBox10Names.Text = zeile[9].Name;
                    tBox10Punktes.Text = zeile[9].Punkte.ToString();
                    tBox10Computers.Text = zeile[9].Computer.ToString();
                }
            }


        }

        private void Button_Click_OK(object sender, RoutedEventArgs e) {
            DialogResult = true;
        }
    }
}
