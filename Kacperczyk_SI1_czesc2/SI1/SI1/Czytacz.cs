using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI1
{
    class Czytacz
    {

        public static String czytajZPliku(String sciezka)
        {
            String znacznik = "NODE_COORD_SECTION";
            String koniec = "EOF";
            int liczbaZnacznika = 18;

            String daneMiastaWNapisie = File.ReadAllText(sciezka);
            int startZnacznika = daneMiastaWNapisie.IndexOf(znacznik);
            daneMiastaWNapisie = daneMiastaWNapisie.Substring(startZnacznika + liczbaZnacznika);
            daneMiastaWNapisie = daneMiastaWNapisie.Replace(koniec,"");
            daneMiastaWNapisie = daneMiastaWNapisie.Replace(".", ",");

          //  Console.WriteLine(daneMiastaWNapisie);/////////////////////////////////////////////////////////////////////////////////////////////////////////
            return daneMiastaWNapisie;
        }

        public static List<Wezel> stworzWezlyMiasta(String daneMiasta)
        {
            String[] podzielniki = { " ", "  ", "\n", "\t" };
            String[] kolejneDane = daneMiasta.Split(podzielniki, StringSplitOptions.RemoveEmptyEntries);

            List <Wezel> wspolczynniki = new List<Wezel>();
            for (int wezel = 0; wezel < kolejneDane.Length/3; wezel++)
            {
                wspolczynniki.Add(new Wezel(float.Parse(kolejneDane[wezel * 3]), float.Parse(kolejneDane[wezel * 3 + 1]),float.Parse(kolejneDane[wezel * 3 + 2])));
                //Console.WriteLine((kolejneDane[wezel * 3 + 1]) + " " + (kolejneDane[wezel * 3 + 2]));
            }
            return wspolczynniki;
        }
    }
}
