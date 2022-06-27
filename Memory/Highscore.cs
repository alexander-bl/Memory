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
namespace Memory {
    public static class Highscore {
        /// <summary>
        /// Schreiben der Highscore-Daten Normal in eine Datei
        /// </summary>
        /// <param name="daten">Highscore-Datensatz</param>
        public static void WriteToFile(Datensatz[] daten) {

            string pfad = @"..\highscoreNormal.txt";

            //Öffnen oder Erstellen der Datei
            using (FileStream fs = new FileStream(pfad, FileMode.OpenOrCreate)) {
                StreamWriter sw = new StreamWriter(fs);

                //Schreiben der Daten durch ; getrennt in Datei
                string text = daten[0].Name + ';' + daten[0].Punkte + ";" + daten[0].Computer + '#';
                for (int i = 1; i < daten.Length; i++) {
                    text = text + daten[i].Name + ';' + daten[i].Punkte + ";" + daten[i].Computer + '#';
                }

                sw.Write(text);

                sw.Flush();
            }

        }
        /// <summary>
        /// Schreiben der Highscore-Daten Schwer in eine Datei
        /// </summary>
        /// <param name="daten">Highscore-Datensatz</param>
        public static void WriteToFileSchwer(Datensatz[] daten) {

            string pfad = @"..\highscoreSchwer.txt";

            //Öffnen oder Erstellen der Datei
            using (FileStream fs = new FileStream(pfad, FileMode.OpenOrCreate)) {
                StreamWriter sw = new StreamWriter(fs);
                //Schreiben der Daten durch ; getrennt in Datei
                string text = daten[0].Name + ';' + daten[0].Punkte + ";" + daten[0].Computer + '#';
                for (int i = 1; i < daten.Length; i++) {
                    text = text + daten[i].Name + ';' + daten[i].Punkte + ";" + daten[i].Computer + '#';
                }

                sw.Write(text);

                sw.Flush();
            }


        }
        /// <summary>
        /// Lesen der Highscore-Daten aus Datei Normal
        /// </summary>
        /// <returns></returns>
        public static Datensatz[] ReadFromFile() {
            string zeile = null;
            FileStream fs = null;
            StreamReader sr = null;
            int count = 0;
            Datensatz[] daten = new Datensatz[0];
            string pfad = @"..\highscoreNormal.txt";
            
            using (fs = new FileStream(pfad, FileMode.OpenOrCreate)) {
                //Wenn Datei gelesen werden kann
                if (fs.CanRead) {   

                    sr = new StreamReader(fs);

                    while (!sr.EndOfStream) {

                        zeile = sr.ReadLine();    // Schreiben des Inhaltes der Datei in string 
                        string[] datensatz = zeile.Split('#');  //Aufteilen des Strings in einzelne Array-Felder pro Datensatz
                       
                        foreach (string inhalt in datensatz) {
                            string[] items = inhalt.Split(';'); //Aufteilen des Arrays in weiter Array-Felder pro Parameter
                            if (!string.IsNullOrEmpty(items[0]) && items[0] != " ") {

                                Array.Resize(ref daten, count + 1); //Erweitern des Arrays um ein Feld
                                daten[count] = new Datensatz(items[0], int.Parse(items[1]), double.Parse(items[2]));    //Erstellen eines Datensatzes mit den aktuellen Parametern
                                count++;
                            }
                        }

                    }
                }
            }
            return daten;

        }
        /// <summary>
        /// Lesen der Highscore-Daten aus Datei Schwer
        /// </summary>
        /// <returns></returns>
        public static Datensatz[] ReadFromFileSchwer() {
            string zeile = null;
            FileStream fs = null;
            StreamReader sr = null;
            int count = 0;
            Datensatz[] daten = new Datensatz[0];
            string pfad = @"..\highscoreSchwer.txt";
            using (fs = new FileStream(pfad, FileMode.OpenOrCreate))
            {//Wenn Datei gelesen werden kann
                if (fs.CanRead)
                {

                    sr = new StreamReader(fs);

                    while (!sr.EndOfStream)
                    {

                        zeile = sr.ReadLine();  // Schreiben des Inhaltes der Datei in string 
                        string[] datensatz = zeile.Split('#');  //Aufteilen des Strings in einzelne Array-Felder pro Datensatz
                        foreach (string inhalt in datensatz)
                        {
                            string[] items = inhalt.Split(';'); //Aufteilen des Arrays in weiter Array-Felder pro Parameter
                            if (!string.IsNullOrEmpty(items[0]) && items[0] != " ")
                            {

                                Array.Resize(ref daten, count + 1); //Erweitern des Arrays um ein Feld
                                daten[count] = new Datensatz(items[0], int.Parse(items[1]), double.Parse(items[2]));    //Erstellen eines Datensatzes mit den aktuellen Parametern
                                count++;
                            }
                        }

                    }

                }
            }
            return daten;
        }

        /// <summary>
        /// Datensatz-Struktur
        /// </summary>
        public struct Datensatz {
            public string Name;
            public int Punkte;
            public double Computer;

            /// <summary>
            /// Default-Konstruktor für Datensatz
            /// </summary>
            /// <param name="name">Name</param>
            /// <param name="punkte">Punkte</param>
            /// <param name="computer">Effektivität des Computers</param>
            public Datensatz(string name = "", int punkte = 0, double computer = 0) {
                Name = name;
                Punkte = punkte;
                Computer = computer;
            }
        }
        /// <summary>
        /// Erweitern des Highscores um einen Datensatz
        /// </summary>
        /// <param name="mensch">Mensch</param>
        /// <param name="computer">Computer</param>
        public static void HIghscore(Mensch mensch, Computer computer) {
            Datensatz[] datensatzs;
            if (computer.Difficulty == "Normal") {  //Wenn Schwirigkeitsgrad Normal ausgewählt wurde
                datensatzs = ReadFromFile();    //Schreibe Daten aus Datei in Datensatz
            } else {
                datensatzs = ReadFromFileSchwer();
            }
            
            Array.Resize(ref datensatzs, datensatzs.Length + 1);    //Erweitern des Arrays um ein Feld
            double effektivität = computer.AnzahlRichtigerPaare*100 / computer.AnzahlGefundenerPaare;  //Berechnung der Effektivität des Computers
            datensatzs[datensatzs.Length - 1] = new Datensatz(mensch.Name, mensch.Score, effektivität); //Schreiben des neuen Datensatzes an die letzte Stelle des Arrays
            bubbleSortSelfemade(ref datensatzs);
            if (computer.Difficulty == "Normal") {  //Wenn Schwierigkeitsgrad Normal ist
                WriteToFile(datensatzs);
            } else {
                WriteToFileSchwer(datensatzs);
            }
            
        }
        /// <summary>
        /// Sortieren der Highscoredaten nach Punkten
        /// </summary>
        /// <param name="pListe"></param>
        private static void bubbleSortSelfemade(ref Datensatz[] pListe) {
            for (int i = pListe.Length - 1; i > 0; i--) {
                for (int k = 0; k < i; k++) {   
                    //vertausche Datensätze
                    if (pListe[k].Punkte < pListe[k + 1].Punkte) {  //Wenn Punkte an aktueller Steller kleiner als an nächster Stelle
                        Datensatz speicher = new Datensatz(pListe[k].Name, pListe[k].Punkte, pListe[k].Computer);
                        pListe[k] = pListe[k + 1];
                        pListe[k + 1] = speicher;
                    }
                }
            }
        }
    }
}