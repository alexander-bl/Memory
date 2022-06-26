using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            string[,] Field = new string[4, 4];
            int zufallszahl;
            int var = 15;

            for (int i = 0; i < z; i++)
            {
                for (int n = 0; n < s; n++)
                {

                    string[] Begriffe = Karten.Kartensatz; //ordne dem Array das Feld aus karten zu
                    zufallszahl = rnd.Next(0, var);   //Zuweisung eines zufälligen Wertes zu zufallszahl
                    Field[i, n] = Begriffe[zufallszahl]; //schreibe den Begriff, der an der Stelle der Zufallszahl liegt, dem Feld zu
                    Array.Clear(Begriffe, zufallszahl, 1);  //Lösche das Element, welches an der Stelle zufallszahl liegt
                    //Schiebe die Wete des Arrays nach links, sodass das Feld mit null am Ende steht
                    for (int k = zufallszahl; k < Begriffe.Length - 1; k++)
                    {
                        Begriffe[k] = Begriffe[k + 1];
                    }
                    var--;  //verkleinere die AUswahl der Zufallszahlen

                }
            }


            return Field;

        }

    }



}
