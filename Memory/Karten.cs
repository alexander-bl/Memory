using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory {
    public class Karten
    {
        static string[] _kartensatz;

        public static string[] Kartensatz { get => _kartensatz; set => _kartensatz = value; }

        public Karten()
        {

        }

        public string[] GetKarten()
        {
            Kartensatz = new string[8] { "Informatik", "C#", "Hello World", "Array", "Polymorphie", "Vererbung", "Visual Studio", "Properties" };
           
            return Kartensatz;
            
        }
    }
        
    
}
