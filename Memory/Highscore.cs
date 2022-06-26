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

        public static void WriteToFile(Computer computer, Mensch mensch, ref List<Tuple<String, string, int, string, Double,string, string>> highscores)
        {
            ReadFromFile();
            Highscores(mensch, computer, ref highscores);

            string pfad = @"..\highscoreNormal.txt";

            //Öffnen oder Erstellen der Datei
            using (FileStream fs = new FileStream(pfad, FileMode.OpenOrCreate))
            {
                StreamWriter sw = new StreamWriter(fs);

                sw.Write(highscores);
                sw.Write(";;;;;;;;;;;;;;;;;;;;;;;;;;;;;;");
                

                sw.Flush();
            }
          
        }

        public static string ReadFromFile()
        {
            string zeile = null;
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
                       
                        zeile = sr.ReadLine();
                        string[] data = zeile.Split(';');

                    }

                    

                }
            }
            return zeile;
           
        }

        public static string ReadFromFileSchwer()
        {
            string zeile = null;
            FileStream fs = null;
            StreamReader sr = null;
            string pfad = @"..\highscoreSchwer.txt";
            using (fs = new FileStream(pfad, FileMode.OpenOrCreate))
            {
                if (fs.CanRead)
                {

                    sr = new StreamReader(fs);

                    while (!sr.EndOfStream)
                    {

                        zeile = sr.ReadLine();
                        string[] data = zeile.Split(';');

                    }



                }
            }
            return zeile;

        }

        public static List<Tuple<String,string,int,string, Double,string, string>> Highscores(Mensch mensch, Computer computer, ref List<Tuple<String, string, int, string, Double,string, string>> highscores)
        {
            double erfolgsquote = (computer.AnzahlRichtigerPaare / computer.AnzahlAufgedecktePaare) * 100; 

            highscores.Add(new Tuple<String, string, int,string, Double,string, string>(mensch.Name,";",mensch.Score,";", erfolgsquote,"%",";"));

            highscores.Sort((s1, s2) => s1.Item3.CompareTo(s2.Item3));


            return highscores;

        }


    }







}