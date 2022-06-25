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
    /// Interaktionslogik für Neues_Spiel_Fenster.xaml
    /// </summary>
    public partial class Neues_Spiel_Fenster : Window {
        string _schwierigkeitsgrad = null;//Computer Schwierigkeitsgrad
        string _name = null;//Name des Mensch Spielers

        SpielFeld _spielFeld = null;//Spielfeld für erstellung des Spiels
        Mensch _mensch = null;//Mensch für Neues Spiel
        Computer _computer = null;//Computer für neues Spiel

        public SpielFeld SpielFeld {
            get => _spielFeld;
            set {
                _spielFeld = value ?? throw new ArgumentNullException(
                                    "Kein Spielfeld vorhanden");
            }
        }
        public Mensch Mensch {
            get => _mensch;
            set {
                _mensch = value ?? throw new ArgumentNullException(
                                    "Kein Mensch vorhanden");
            }
        }
        public Computer Computer {
            get => _computer;
            set {
                _computer = value ?? throw new ArgumentNullException(
                                    "Kein Computer vorhanden");
            }
        }

        public Neues_Spiel_Fenster() {
            InitializeComponent();
        }

        private void tBox_Name_TextChanged(object sender, TextChangedEventArgs e) {
            _name = tBox_Name.Text;
        }

        private void okButton_Click(object sender, RoutedEventArgs e) {
            try {
                SpielFeld = new SpielFeld();
                Computer = new Computer(_schwierigkeitsgrad, false);
                Mensch = new Mensch(_name, true);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Fehler");
                return;
            }
            
            DialogResult = true;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e) {
            DialogResult = false;
        }

        private void RadioButton_Checked_Normal(object sender, RoutedEventArgs e) {
            _schwierigkeitsgrad = "Normal";
        }

        private void RadioButton_Checked_Schwer(object sender, RoutedEventArgs e) {
            _schwierigkeitsgrad = "Schwer";
        }
    }
}
