using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Memberobjekt von Spielfeld
 * Autoren: Alexander Bletsch, Anna Stork
 * Erstellt: 09.06.22
 */

namespace Memory {
    public class Karten
    {
        //Feld
        static string[] _kartensatz;
        //Propertie
        public static string[] Kartensatz 
        { 
          get => _kartensatz;
            set
            {
                if (value == null)  
                {
                    throw new ArgumentNullException("Das Feld darf nicht leer sein!");
                }
                _kartensatz = value;
            }
        }

        /// <summary>
        /// Default-Kontruktor der Klasse Karten
        /// </summary>
        public Karten()
        {
            Kartensatz = AuswahlKartensatz();
        }
        /// <summary>
        /// Methode zum Erstellen eines Kartensatzes
        /// </summary>
        /// <returns>Kartensatz</returns>
        public string[] AuswahlKartensatz()
        {
            string[] Inhalt = new string[8] { "Informatik", "C#", "Hello World", "Array", "Polymorphie", "Vererbung", "Visual Studio", "Properties" };
           
            return Inhalt ;
            
        }
    }
        
    
}
