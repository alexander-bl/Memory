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

namespace Memory
{
    /// <summary>
    /// Interaktionslogik für Highscore_Fenster.xaml
    /// </summary>
    public partial class Highscore_Fenster : Window
    {
        public Highscore_Fenster()
        {
            InitializeComponent();

            Computer computer = null;

            string zeile;

            if (Computer.difficulty == "Normal")
           {

                zeile = Highscore.ReadFromFile();
                string[] data = zeile.Split(';');
                if (data[0] != null)
                {
                    tBox1Name.Text = data[0];
                    tBox1Punkte.Text = data[1];
                    tBox1Computer.Text = data[2];
                }
                if (data.Length > 4)
                {

                    tBox2Name.Text = data[3];
                    tBox2Punkte.Text = data[4];
                    tBox2Computer.Text = data[5];
                }
                if (data.Length > 7)
                {
                    tBox3Name.Text = data[6];
                    tBox3Punkte.Text = data[7];
                    tBox3Computer.Text = data[8];
                }
                if (data.Length > 10)
                {
                    tBox4Name.Text = data[9];
                    tBox4Punkte.Text = data[10];
                    tBox4Computer.Text = data[11];
                }
                if (data.Length > 13)
                {
                    tBox5Name.Text = data[12];
                    tBox5Punkte.Text = data[13];
                    tBox5Computer.Text = data[14];
                }
                if (data.Length > 16)
                {
                    tBox6Name.Text = data[15];
                    tBox6Punkte.Text = data[16];
                    tBox6Computer.Text = data[17];
                }
                if (data.Length > 19)
                {
                    tBox7Name.Text = data[18];
                    tBox7Punkte.Text = data[19];
                    tBox7Computer.Text = data[20];
                }
                if (data.Length > 22)
                {
                    tBox8Name.Text = data[21];
                    tBox8Punkte.Text = data[22];
                    tBox8Computer.Text = data[23];
                }
                if (data.Length > 25)
                {
                    tBox9Name.Text = data[24];
                    tBox9Punkte.Text = data[25];
                    tBox9Computer.Text = data[26];
                }
                if (data.Length > 28)
                {
                    tBox10Name.Text = data[27];
                    tBox10Punkte.Text = data[28];
                    tBox10Computer.Text = data[29];
                }
            }
            else
            {
                zeile = Highscore.ReadFromFileSchwer();
                string[] data = zeile.Split(';');
                if (data[0] != null)
                {
                    tBox1Names.Text = data[0];
                    tBox1Punktes.Text = data[1];
                    tBox1Computers.Text = data[2];
                }
                if (data.Length > 4)
                {

                    tBox2Names.Text = data[3];
                    tBox2Punktes.Text = data[4];
                    tBox2Computers.Text = data[5];
                }
                if (data.Length > 7)
                {
                    tBox3Names.Text = data[6];
                    tBox3Punktes.Text = data[7];
                    tBox3Computers.Text = data[8];
                }
                if (data.Length > 10)
                {
                    tBox4Names.Text = data[9];
                    tBox4Punktes.Text = data[10];
                    tBox4Computers.Text = data[11];
                }
                if (data.Length > 13)
                {
                    tBox5Names.Text = data[12];
                    tBox5Punktes.Text = data[13];
                    tBox5Computers.Text = data[14];
                }
                if (data.Length > 16)
                {
                    tBox6Names.Text = data[15];
                    tBox6Punktes.Text = data[16];
                    tBox6Computers.Text = data[17];
                }
                if (data.Length > 19)
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


    }
}
