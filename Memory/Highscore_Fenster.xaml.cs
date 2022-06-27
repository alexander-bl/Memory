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
                if (zeile.Length > 0) {
                    tBox1Name.Text = zeile[0].Name;
                    tBox1Punkte.Text = zeile[0].Punkte.ToString();
                    tBox1Computer.Text = zeile[0].Computer.ToString();
                    tBox1Punkte.Text = data[1];
                if (zeile.Length > 1) {
                }
                if (data.Length > 4)
                {

                    tBox2Name.Text = zeile[1].Name;
                if (zeile.Length > 2) {
                    tBox3Name.Text = zeile[2].Name;
                    tBox3Punkte.Text = zeile[2].Punkte.ToString();
                    tBox3Computer.Text = zeile[2].Computer.ToString();
                {
                if (zeile.Length > 3) {
                    tBox4Name.Text = zeile[3].Name;
                    tBox4Punkte.Text = zeile[3].Punkte.ToString();
                    tBox4Computer.Text = zeile[3].Computer.ToString();
                if (data.Length > 10)
                if (zeile.Length > 4) {
                    tBox5Name.Text = zeile[4].Name;
                    tBox5Punkte.Text = zeile[4].Punkte.ToString();
                    tBox5Computer.Text = zeile[4].Computer.ToString();
                }
                if (zeile.Length > 5) {
                    tBox6Name.Text = zeile[5].Name;
                    tBox6Punkte.Text = zeile[5].Punkte.ToString();
                    tBox6Computer.Text = zeile[5].Computer.ToString();
                    tBox5Computer.Text = data[14];
                if (zeile.Length > 6) {
                    tBox7Name.Text = zeile[6].Name;
                    tBox7Punkte.Text = zeile[6].Punkte.ToString();
                    tBox7Computer.Text = zeile[6].Computer.ToString();
                    tBox6Punkte.Text = data[16];
                if (zeile.Length > 7) {
                    tBox8Name.Text = zeile[7].Name;
                    tBox8Punkte.Text = zeile[7].Punkte.ToString();
                    tBox8Computer.Text = zeile[7].Computer.ToString();
                    tBox7Name.Text = data[18];
                if (zeile.Length > 8) {
                    tBox9Name.Text = zeile[8].Name;
                    tBox9Punkte.Text = zeile[8].Punkte.ToString();
                    tBox9Computer.Text = zeile[8].Computer.ToString();
                {
                if (zeile.Length > 9) {
                    tBox10Name.Text = zeile[9].Name;
                    tBox10Punkte.Text = zeile[9].Punkte.ToString();
                    tBox10Computer.Text = zeile[9].Computer.ToString();
                if (data.Length > 25)
                {
                    tBox9Name.Text = data[24];
                    tBox9Punkte.Text = data[25];
                    tBox9Computer.Text = data[26];
                if (zeile.Length > 0) {
                    tBox1Names.Text = zeile[0].Name;
                    tBox1Punktes.Text = zeile[0].Punkte.ToString();
                    tBox1Computers.Text = zeile[0].Computer.ToString();
                    tBox10Punkte.Text = data[28];
                if (zeile.Length > 1) {
                }
            }

            if (Highscore.ReadFromFileSchwer() != null) {
                zeile = Highscore.ReadFromFileSchwer();
                if (zeile.Length > 2) {
                    tBox3Names.Text = zeile[2].Name;
                    tBox3Punktes.Text = zeile[2].Punkte.ToString();
                    tBox3Computers.Text = zeile[2].Computer.ToString();
                    tBox1Punktes.Text = data[1];
                if (zeile.Length > 3) {
                    tBox4Names.Text = zeile[3].Name;
                    tBox4Punktes.Text = zeile[3].Punkte.ToString();
                    tBox4Computers.Text = zeile[3].Computer.ToString();

                if (zeile.Length > 4) {
                    tBox5Names.Text = zeile[4].Name;
                    tBox5Punktes.Text = zeile[4].Punkte.ToString();
                    tBox5Computers.Text = zeile[4].Computer.ToString();
                if (data.Length > 7)
                if (zeile.Length > 5) {
                    tBox6Names.Text = zeile[5].Name;
                    tBox6Punktes.Text = zeile[5].Punkte.ToString();
                    tBox6Computers.Text = zeile[5].Computer.ToString();
                }
                if (zeile.Length > 6) {
                    tBox7Names.Text = zeile[6].Name;
                    tBox7Punktes.Text = zeile[6].Punkte.ToString();
                    tBox7Computers.Text = zeile[6].Computer.ToString();
                    tBox4Computers.Text = data[11];
                if (zeile.Length > 7) {
                    tBox8Names.Text = zeile[7].Name;
                    tBox8Punktes.Text = zeile[7].Punkte.ToString();
                    tBox8Computers.Text = zeile[7].Computer.ToString();
                    tBox5Punktes.Text = data[13];
                if (zeile.Length > 8) {
                    tBox9Names.Text = zeile[8].Name;
                    tBox9Punktes.Text = zeile[8].Punkte.ToString();
                    tBox9Computers.Text = zeile[8].Computer.ToString();
                    tBox6Names.Text = data[15];
                if (zeile.Length > 9) {
                    tBox10Names.Text = zeile[9].Name;
                    tBox10Punktes.Text = zeile[9].Punkte.ToString();
                    tBox10Computers.Text = zeile[9].Computer.ToString();
                {
                    tBox7Names.Text = data[18];
                    tBox7Punktes.Text = data[19];
                    tBox7Computers.Text = data[20];
                }
                if (data.Length > 22)
                {
                    tBox8Names.Text = data[21];
                    tBox8Punktes.Text = data[22];
                    tBox8Computers.Text = data[23];
                }
                if (data.Length > 25)
                {
                    tBox9Names.Text = data[24];
                    tBox9Punktes.Text = data[25];
                    tBox9Computers.Text = data[26];
                }
                if (data.Length > 28)
                {
                    tBox10Names.Text = data[27];
                    tBox10Punktes.Text = data[28];
                    tBox10Computers.Text = data[29];
                }
            }


        }

        private void Button_Click_OK(object sender, RoutedEventArgs e) {
            DialogResult = true;
        }
    }
}
