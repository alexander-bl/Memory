using System;

namespace Memory
{
    public class SpielFeld
    {
        //Felder
        string[,] _feld;
        Karten _karten;

        //Properties
        public string[,] Feld
        {
            get => _feld;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Das Feld darf nicht leer sein!");
                }


                _feld = value;
            }

        }

        public Karten Karten
        {
            get => _karten;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Keine Karten vorhanden!!");
                }
                _karten = value;
            }
        }

        /// <summary>
        /// Konstruktor der Klasse Spielfeld
        /// </summary>
        /// <param name="_karten">Kartensatz</param>
        public SpielFeld()
        {
            Karten = new Karten();
            Feld = ErzeugeSpielfeld();
        }

        /// <summary>
        /// Methode zum zufälligen Verteilen der Begriffe auf die Felder des Arrays
        /// </summary>
        private string[,] ErzeugeSpielfeld()
        {

            Random rnd = new Random();
            int s = 4, z = 4;

            int[] anzahl = new int[8];  //Erzeugen eines Arrays zum speichern, wie oft ein Begriff vorhanden ist

            bool ok = false;
            int zufallszahl;

            for (int i = 0; i < z; i++)
            {
                for (int n = 0; n < s; n++)
                {
                    do
                    {
                        zufallszahl = rnd.Next(0, 8);   //Zuweisung eines zufälligen Wertes zu zufallszahl
                        ok = false;

                        // Erhöhe Anzahl an der Stelle j, wenn zahl j gegeben ist
                        for (int j = 0; j < zufallszahl + 1; j++)
                        {
                            if (zufallszahl == j)
                            {
                                anzahl[j]++;
                            }
                        }

                        //Wenn anzahl an der gegebene Stelle kleiner gleich 2 ist, setze ok auf true
                        if (anzahl[zufallszahl] <= 2)
                        {
                            ok = true;
                        }

                    } while (!ok);//wiederhole dies, bis eine passende Zahl gefunden wurde

                    string[] Begriffe = Karten.Kartensatz; //ordne dem Array das Feld aus der Methode GetKarten zu
                    Feld[i, n] = Begriffe[zufallszahl]; //schreibe den Begriff, der an der Stelle der Zufallszahl liegt, dem Feld zu

                }
            }

            return Feld;

        }

    }



}
