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
    public static class Highscore
    {

        public static void WriteToFile(Computer computer, Mensch mensch)
        {
            string pfad = @"..\highscoreNormal.txt";
            if (!File.Exists(pfad))  //Wenn Datei nicht existiert
            {
                //Öffnen oder Erstellen der Datei
                using (FileStream fs = new FileStream(pfad, FileMode.OpenOrCreate))
                {
                    StreamWriter sw = new StreamWriter(fs);


                    sw.Write(String.Format("{0,20},{1,20};", mensch.Name, mensch.Score));

                    sw.Flush(); //Schreiben erzwingen
                }
            }
            else
            {
                //anhängen an Dateiende
                using (FileStream fs = new FileStream(pfad, FileMode.Append))
                {
                    StreamWriter sw = new StreamWriter(fs);

                    sw.Write(String.Format("{0,20},{1,20};", mensch.Name, mensch.Score));


                    sw.Flush(); //Schreiben erzwingen
                }
            }


        }

        public static void ReadFromFile(Computer computer, Mensch mensch)
        {
            int[] Score = null;
            int score;
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
                        for (int i = 0; i < Score.Length; i++)
                        {
                            string[] data = null;

                            line = sr.ReadLine(); //Lesen aller Datensätze in eine Zeichenkette!
                            //data[i] = line.Split(';');
                        }
                    }

                    for (int i = 0; i < line.Length; i++)
                    {
                        int.TryParse(line, out score);
                        Score[i] = score;
                    }

                }
            }
        }

        public static int[] Sort(Computer computer, Mensch mensch)
        {

            for (int i = Score.Length + 1; i < Score.Length + 2; i++)
            {
                Score[i] = mensch.Score;
                Name[i] = mensch.Name;
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

        public static void Highscores(Mensch mensch, Computer computer)
        {
            Highscore[] highscores = null;
            for (int i = 0; i < highscores.Length; i++)
            {
                Array.Resize(ref highscores, highscores.Length + 1);
                highscores[i] = new Highscore(mensch.Name, mensch.Score);

            }
            highscores[highscores.Length] = mensch.Name + mensch.Score;
        }

        private void bubbleSort(ref Mensch[] pListe)
        {
            for (int i = pListe.Length - 1; i > 0; i--)
            {
                for (int k = 0; k < i; k++)
                {
                    if (pListe[k].Score < pListe[k + 1].Score) //vertausche
                    {
                        Mensch speicher = new(pListe[k]);
                        pListe[k] = pListe[k + 1];
                        pListe[k + 1] = speicher;
                    }
                }
            }
        }*/
    }







}