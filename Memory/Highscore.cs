using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/*
 * Highscore Klasse
 * Autoren: Alexander Bletsch, Anna Stork
 * Erstellt: 09.06.22
 */
namespace Memory
{
    static class Highscore
    {
        public static void WriteToFile(Spieler spieler)
        {
            string pfad = @"..\highscoreNormal.txt";
            using (FileStream fs = new FileStream(pfad, FileMode.OpenOrCreate))
            {
                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine(String.Format("{0,20}\t,{1,20}\n\n,{3,20}\t,{4,20}\n",
                "Name", "Punkte", spieler.GetName(), spieler.Score));

                sw.Flush(); //Schreiben erzwingen
            }
        }

        public static void ReadFromFile()
        {
            bool ok = true;
            FileStream fs = null;
            StreamReader sr = null;
            string pfad = @"..\highscoreNormal.txt";
            using (fs = new FileStream(pfad, FileMode.OpenOrCreate))
            {
                if (fs.CanRead)
                {

                    string line = "";

                    sr = new StreamReader(fs);

                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine(); //Lesen aller Datensätze in eine Zeichenkette!

                    }

                }//foreach
            }//while
        }//if
    }//using





}
    

