using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Kindklasse von Spieler
 * Autoren: Alexander Bletsch, Anna Stork
 * Erstellt: 09.06.22
 */
namespace Memory {
    public class Mensch : Spieler {
        string _name;

        public Mensch(string name) :base(){
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

        public override string GetName() {
            return Name;
        }
    }
}
