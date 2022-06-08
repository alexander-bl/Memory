using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory {
    public class Mensch : Spieler {
        string _name;

        public Mensch(string name, int highscore, int punkte) :base(){
            Name = name;
        }

        public string Name {
            get => _name;
            set {
                _name = value;
            }
        }

        public override void FeldAnschauen() {

        }

        public override void Gedaechtnis() {
            
        }
    }
}
