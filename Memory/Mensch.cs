using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory {
    internal class Mensch : Spieler {
        string _name;

        public string Name {
            get => _name;
            set {
                _name = value;
            }
        }
    }
}
