/*
 * Member Objekt von Spieler
 * Autoren: Alexander Bletsch, Anna Stork
 * Erstellt: 09.06.22
 */

namespace Memory {
    /// <summary>
    /// Struktur zum Speichern von Karten
    /// </summary>
    public struct KnownCard {

        /// <summary>
        /// Standard Konstruktor
        /// </summary>
        /// <param name="karte"></param>
        /// <param name="zeile"></param>
        /// <param name="spalte"></param>
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
