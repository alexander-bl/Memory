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
    public class Highscore
    {
        static string[,] _highscoreData;
        static int[] score;
        static string[] name;

        public static string[,] HighscoreData
        {
            get => _highscoreData;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Der Highscore darf nicht leer sein!");
                }


                _highscoreData = value;
            }
        }

        public static int[] Score { get => score; set => score = value; }
        public static string[] Name { get => name; set => name = value; }

        public Highscore()
        {
            HighscoreData = ;
        }
        public static void WriteToFile(Computer computer, Mensch mensch)
        {
            string pfad = @"..\highscoreNormal.txt";
            if (!File.Exists(pfad))  //Wenn Datei nicht existiert
            {
                //Öffnen oder Erstellen der Datei
                using (FileStream fs = new FileStream(pfad, FileMode.OpenOrCreate))
                {
                    StreamWriter sw = new StreamWriter(fs);

                    
                        sw.Write(String.Format("{0,20},{1,20}", mensch.Name, mensch.Score));
                    
                    sw.Flush(); //Schreiben erzwingen
                }
            }
            else
            {
                //anhängen an Dateiende
                using (FileStream fs = new FileStream(pfad, FileMode.Append))
                {
                    StreamWriter sw = new StreamWriter(fs);

                        sw.Write(String.Format("{0,20},{1,20}", mensch.Name, mensch.Score));
                        
                    
                    sw.Flush(); //Schreiben erzwingen
                }
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

                }
            }
        }

        public static int[] Sort(Spieler spieler, Mensch mensch)
        {
            
            for (int i = Score.Length+1; i < Score.Length+2;i++ )
            {
                Score[i] = mensch.Score;
                Name[i] = spieler.GetName();
            }

            bool vertauscht;
            do
            {
                vertauscht = false;
                for (int i = 0; i < Score.Length - 2; i++)
                {
                    if (Score[i] > Score[i + 1])
                    {
                        int puffer = Score[i];
                        string puffername = Name[i];
                        Score[i] = Score[i + 1];
                        Name[i] = Name[i + 1];
                        Score[i + 1] = puffer;
                        Name[i + 1] = puffername;

                        vertauscht = true;
                    }
                }
            } while (vertauscht);


    
            int[] SortedHighscore = new int[Score.Length + Name.Length];
            Array.Copy(Score, SortedHighscore, Score.Length);
            Array.Copy(Name, 0, SortedHighscore, Score.Length, Name.Length);
            
           
            

            return SortedHighscore;
            
        }
    }





}
    

