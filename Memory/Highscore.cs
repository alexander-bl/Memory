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

        public static void WriteToFile(Datensatz[] daten) {

            string pfad = @"..\highscoreNormal.txt";

            //Öffnen oder Erstellen der Datei
            using (FileStream fs = new FileStream(pfad, FileMode.OpenOrCreate)) {
                StreamWriter sw = new StreamWriter(fs);

                string text = daten[0].Name + ';' + daten[0].Punkte + ";" + daten[0].Computer + '#';
                for (int i = 1; i < daten.Length; i++) {
                    text = text + daten[i].Name + ';' + daten[i].Punkte + ";" + daten[i].Computer + '#';
                }

                sw.Write(text);

                sw.Flush();
            }

        }

        public static void WriteToFileSchwer(Datensatz[] daten) {

            string pfad = @"..\highscoreSchwer.txt";

            //Öffnen oder Erstellen der Datei
            using (FileStream fs = new FileStream(pfad, FileMode.OpenOrCreate)) {
                StreamWriter sw = new StreamWriter(fs);

                string text = daten[0].Name + ';' + daten[0].Punkte + ";" + daten[0].Computer + '#';
                for (int i = 1; i < daten.Length; i++) {
                    text = text + daten[i].Name + ';' + daten[i].Punkte + ";" + daten[i].Computer + '#';
                }

                sw.Write(text);

                sw.Flush();
            }


        }

        public static Datensatz[] ReadFromFile() {
            string zeile = null;
            FileStream fs = null;
            StreamReader sr = null;
            int count = 0;
            Datensatz[] daten = new Datensatz[0];
            string pfad = @"..\highscoreNormal.txt";
            using (fs = new FileStream(pfad, FileMode.OpenOrCreate)) {
                if (fs.CanRead) {

                    sr = new StreamReader(fs);

                    while (!sr.EndOfStream) {

                        zeile = sr.ReadLine();
                        string[] datensatz = zeile.Split('#');
                        foreach (string inhalt in datensatz) {
                            string[] items = inhalt.Split(';');
                            if (!string.IsNullOrEmpty(items[0]) && items[0] != " ") {

                                Array.Resize(ref daten, count + 1);
                                daten[count] = new Datensatz(items[0], int.Parse(items[1]), double.Parse(items[2]));
                                count++;
                            }
                        }

                    }



                }
            }
            return daten;

        }

        public static Datensatz[] ReadFromFileSchwer() {
            string zeile = null;
            FileStream fs = null;
            StreamReader sr = null;
            int count = 0;
            Datensatz[] daten = new Datensatz[0];
            string pfad = @"..\highscoreSchwer.txt";
            using (fs = new FileStream(pfad, FileMode.OpenOrCreate)) {
                if (fs.CanRead) {

                    sr = new StreamReader(fs);

                    while (!sr.EndOfStream) {

                        zeile = sr.ReadLine();
                        string[] datensatz = zeile.Split('#');
                        foreach (string inhalt in datensatz)
                        {
                            string[] items = inhalt.Split(';');
                            if (!string.IsNullOrEmpty(items[0]) && items[0] != " ")
                            {

                                Array.Resize(ref daten, count + 1);
                                daten[count] = new Datensatz(items[0], int.Parse(items[1]), double.Parse(items[2]));
                                count++;
                            }
                        }

                    }



                }
            }
            return daten;

        }





        public struct Datensatz {
            public string Name;
            public int Punkte;
            public double Computer;

            public Datensatz(string name = "", int punkte = 0, double computer = 0) {
                Name = name;
                Punkte = punkte;
                Computer = computer;
            }
        }

        public static void HIghscore(Mensch mensch, Computer computer) {
            Datensatz[] datensatzs;
            if (computer.Difficulty == "Normal") {
                datensatzs = ReadFromFile();
            } else {
                datensatzs = ReadFromFileSchwer();
            }
            
            Array.Resize(ref datensatzs, datensatzs.Length + 1);
            double effektivität = computer.AnzahlRichtigerPaare*100 / computer.AnzahlAufgedecktePaare;
            datensatzs[datensatzs.Length - 1] = new Datensatz(mensch.Name, mensch.Score, effektivität);
            bubbleSortSelfemade(ref datensatzs);
            if (computer.Difficulty == "Normal") {
                WriteToFile(datensatzs);
            } else {
                WriteToFileSchwer(datensatzs);
            }
            

        }

        private static void bubbleSortSelfemade(ref Datensatz[] pListe) {
            for (int i = pListe.Length - 1; i > 0; i--) {
                for (int k = 0; k < i; k++) {
                    if (pListe[k].Punkte < pListe[k + 1].Punkte) {
                        Datensatz speicher = new Datensatz(pListe[k].Name, pListe[k].Punkte, pListe[k].Computer);
                        pListe[k] = pListe[k + 1];
                        pListe[k + 1] = speicher;
                    }
                }
            }
        }
    }







}