using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI1
{
    class SelekcjaRuletka
    {
        List<Osobnik> osobnicyPopulacji = new List<Osobnik>();
        List<double> wagiOsobnikowWPopulacji = new List<double>();
        List<double> procentyOsobnikowPopulacji = new List<double>();
        List<Tuple<double, double>> przedzialyProcentowePopulacji = new List<Tuple<double, double>>();
        Random losowaczRuletkowy = new Random();

        public SelekcjaRuletka(List<Osobnik> osobnicy)
        {
            osobnicyPopulacji = osobnicy;
            double najgorszaFunkcjaDlaTejPopulacji = najgorszaFunkcjCeluWPopulacji();
            stworzWagiPopulacji(najgorszaFunkcjaDlaTejPopulacji);
            double sumaWagWPopulacji = sumaWag();
            stworzProcentyPopulacji(sumaWagWPopulacji);
            stworzPrzedzialyProcentowePopulacji();
        }

        public double najgorszaFunkcjCeluWPopulacji()
        {
            double najgorszy = 0;
            foreach (Osobnik czescPopulacji in osobnicyPopulacji)
            {
                double czyNajgorszy = czescPopulacji.funkcjaCelu();
                //Console.WriteLine(czyNajgorszy);
                if (czyNajgorszy > najgorszy)
                {
                    najgorszy = czyNajgorszy;
                }
            }
            //Console.WriteLine("321   " + najgorszy);
            return najgorszy;
        }

        public void stworzWagiPopulacji(double maxik)
        {
            int epsilon = 1;
            foreach (Osobnik doZwarzenia in osobnicyPopulacji)
            {
                wagiOsobnikowWPopulacji.Add(maxik - doZwarzenia.funkcjaCelu() + epsilon);
            }
        }

        public double sumaWag()
        {
            double suma = 0;
            foreach (double waga in wagiOsobnikowWPopulacji)
            {
                suma += waga;
            }
            return suma;
        }

        public void stworzProcentyPopulacji(double suma)
        {
            foreach (double waga in wagiOsobnikowWPopulacji)
            {
                procentyOsobnikowPopulacji.Add((waga / suma) * 100);
            }
        }

        public void stworzPrzedzialyProcentowePopulacji()
        {
            double procentStartowy = 0;
            foreach (double procent in procentyOsobnikowPopulacji)
            {
                przedzialyProcentowePopulacji.Add(new Tuple<double, double>(procentStartowy, procentStartowy + procent));
                procentStartowy += procent;
               // Console.WriteLine(procentStartowy);
            }
        }

        public Osobnik wybranyOsobnik()
        {
            double wylosowanyPrzezRuletke = losowaczRuletkowy.NextDouble() * 100;
            Console.WriteLine(wylosowanyPrzezRuletke);
            Osobnik wybrany = osobnicyPopulacji[0];
            int index = 0;
            foreach (Tuple<double,double> przedzial in przedzialyProcentowePopulacji)
            {
                if (wylosowanyPrzezRuletke > przedzial.Item1 && wylosowanyPrzezRuletke < przedzial.Item2)
                {
                    Console.WriteLine(przedzial.Item1 + "   " + przedzial.Item2);
                    return osobnicyPopulacji[index];
                }
                index++;
            }
            return wybrany;
        }
    }
}
