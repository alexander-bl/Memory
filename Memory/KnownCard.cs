using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Member Objekt von Spieler
 * Autoren: Alexander Bletsch, Anna Stork
 * Erstellt: 09.06.22
 */

namespace Memory {
    public struct KnownCard {

        public KnownCard(string karte, int zeile, int spalte) {
            Karte = karte;
            Zeile = zeile;
            Spalte = spalte;
        }

        public string Karte { get; set; }

        public int Zeile { get; set; }

        public int Spalte { get; set; }

    }
}
