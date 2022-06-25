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

        public static void WriteToFile(Computer computer, Mensch mensch, ref List<Tuple<String, int, double, string>> highscores)
        {
            ReadFromFile(computer, mensch);
            Highscores(mensch, computer, ref highscores);

            string pfad = @"..\highscoreNormal.txt";

            //Öffnen oder Erstellen der Datei
            using (FileStream fs = new FileStream(pfad, FileMode.OpenOrCreate))
            {
                StreamWriter sw = new StreamWriter(fs);

                sw.Write(highscores);
                sw.Flush();
            }
          
        }

        public static void ReadFromFile(Computer computer, Mensch mensch)
        {
            
            FileStream fs = null;
            StreamReader sr = null;
            string pfad = @"..\highscoreNormal.txt";
            using (fs = new FileStream(pfad, FileMode.OpenOrCreate))
            {
                if (fs.CanRead)
                { 

                    sr = new StreamReader(fs);

                    while (!sr.EndOfStream)
                    {
                        
                        string zeile =  sr.ReadLine();
                        string[] data = zeile.Split('#');
                        


                    }

                    

                }
            }
        }


        public static List<Tuple<String,int, Double, string>> Highscores(Mensch mensch, Computer computer, ref List<Tuple<String, int, Double, string>> highscores)
        {
            double erfolgsquote = (computer.AnzahlRichtigerPaare / computer.AnzahlAufgedecktePaare) * 100; 

            highscores.Add(new Tuple<String,int, Double,string>(mensch.Name,mensch.Score, erfolgsquote,"#"));

            highscores.Sort((s1, s2) => s1.Item2.CompareTo(s2.Item2));

            return highscores;

        }


    }







}