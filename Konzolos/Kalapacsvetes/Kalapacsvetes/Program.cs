using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalapacsvetes
{
    internal class Program
    {
        static List<Sportolo> sportolok = new List<Sportolo>();
        static void Main(string[] args)
        {
            sportolok = Beolvas.FileBeolvasas("kalapacsvetes.txt");
            Feladat4();
            Feladat5();
            Feladat6();
            Feladat7();
            Feladat8();
        }

        public static void Feladat4()
        {
            // Határozza meg és írja ki, hány dobás eredménye található a forrásfájlban! 
            Console.WriteLine($"4. feladat: {sportolok.Count} dobás eredménye található.");
        }

        public static void Feladat5()
        {
            //Határozza meg és jelenítse meg a forrásállományban szereplő magyar (HUN) sportolók dobásainak átlageredményét! Az eredményt két tizedesre kerekítve írja ki!
            var magyarSportolok = sportolok.Where(s => s.Orszagkod == "HUN");
            double atlagEredmeny = magyarSportolok.Average(s => s.Eredmeny);
            Console.WriteLine($"5. feladat: A magyar sportolók dobásainak átlageredménye: {atlagEredmeny} métert dobtak.");
        }

        public static void Feladat6()
        {
            //Kérjen be egy évszámot és írja ki, hogy abban az évben mennyi dobás került be a legjobbak közé, illetve írja ki, hogy mely sportolók érték el ezeket.Ellenkező esetben írja ki, hogy az adott évben nem került be egy dobás eredménye sem a legjobbak közé
            Console.Write("6. feladat: Kérem adjon meg egy évszámot: ");
            int evszam = int.Parse(Console.ReadLine());
            Console.WriteLine($"Az adott évben {sportolok.Count(s => s.Datum.Year == evszam)} dobás került be a legjobbak közé.");
            var sportolokEvben = sportolok.Where(s => s.Datum.Year == evszam);
            Console.WriteLine($"Az adott évben a következő sportolók érték el ezeket: {string.Join(", ", sportolokEvben.Select(s => s.SportoloNev))}");

        }

        public static void Feladat7()
        {
            //Készítsen statisztikát, hogy melyik országból hány kalapácsvetés eredménye szerepel a legjobb dobások között. Az eredményt a mintának megfelelően írassa ki a képernyőre!
            Console.WriteLine("7. feladat: Statisztika a legjobb dobások között szereplő országokról:");
            var statisztika = sportolok.GroupBy(s => s.Orszagkod)
                .Select(g => new { Orszagkod = g.Key, DobasokSzama = g.Count() })
                .OrderByDescending(s => s.DobasokSzama);
            Console.WriteLine("Országkód\tDobások száma");
            foreach (var item in statisztika)
            {
                Console.WriteLine($"{item.Orszagkod}\t\t{item.DobasokSzama}");
            }
        }

        public static void Feladat8()
        {
            //Hozzon létre magyarok.txt néven egy UTF-8 kódolású fájlt, amelyben csak a magyar (HUN)sportolók eredményei szerepelnek.
            var magyarSportolok = sportolok.Where(s => s.Orszagkod == "HUN");
            using (StreamWriter sw = new StreamWriter("magyarok.txt", false, Encoding.UTF8))
            {
                sw.WriteLine("Helyezés;Eredmény;Sportoló neve;Országkód;Helyszín;Dátum");
                foreach (var sportolo in magyarSportolok)
                {
                    sw.WriteLine($"{sportolo.Helyezes};{sportolo.Eredmeny};{sportolo.SportoloNev};{sportolo.Orszagkod};{sportolo.Helyszin};{sportolo.Datum:yyyy-MM-dd}");
                }
            }
        }
    }


}
