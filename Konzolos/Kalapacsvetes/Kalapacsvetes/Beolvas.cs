using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalapacsvetes
{
    internal class Beolvas
    {
        public static List<Sportolo> FileBeolvasas(string filepath)
        {
            List<Sportolo> sportolok = new List<Sportolo>();

            using (StreamReader sr = new StreamReader("kalapacsvetes.txt"))
            {
                string line = sr.ReadLine();
                if (line != null)
                {
                    Console.WriteLine(line);
                }
                while ((line = sr.ReadLine()) != null)
                {
                    string[] adatok = line.Split(';');
                    int helyezes = int.Parse(adatok[0]);
                    double eredmeny = double.Parse(adatok[1]);
                    string sportolonev = adatok[2];
                    string orszagkod = adatok[3];
                    string helyszin = adatok[4];
                    DateTime datum = DateTime.Parse(adatok[5]);
                    Sportolo sportolo = new Sportolo(helyezes, eredmeny, sportolonev, orszagkod, helyszin, datum);
                    sportolok.Add(sportolo);
                }
            }
            return sportolok;
        }
    }
}
