using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI1
{
    class AlgorytmGenetyczny
    {
        List<Osobnik> osobnicyPopulacji = new List<Osobnik>();
        int liczbaOsobnikowWPopulacji = 0;
        int ilePokolen = 0;
        int NWTurnieju = 0;
        Miasto problemDoRozwiazania;
        List<double> koloRuketki = new List<double>();
        Random losowacz = new Random();
        double prawdopodobienstwoKrzyzowania = 1;
        double prawdopodobienstwoMutacji = 1;

        public AlgorytmGenetyczny(Miasto problem, int ileWPopulacji, int NosobnikowTurnieju, int liczbaPokolen, double pK, double pM)
        {
            liczbaOsobnikowWPopulacji = ileWPopulacji;
            problemDoRozwiazania = problem;
            ilePokolen = liczbaPokolen;
            NWTurnieju = NosobnikowTurnieju;
            prawdopodobienstwoKrzyzowania = pK;
            prawdopodobienstwoMutacji = pM;
            this.inicjalizacja();
            

        }

        public void inicjalizacja()
        {
            for(int ile = 0; ile < liczbaOsobnikowWPopulacji; ile++)
            {
                osobnicyPopulacji.Add(new Osobnik(problemDoRozwiazania, "LOSOWY"));
            }
        }

        public void zrobOstatniePokolenie()
        {
            for (int pokolenie = 1; pokolenie < ilePokolen; pokolenie++)
            {
                SelekcjaTurniejem selekcja = new SelekcjaTurniejem(NWTurnieju, osobnicyPopulacji);
                //SelekcjaRuletka selekcja = new SelekcjaRuletka(osobnicyPopulacji);

                List<Osobnik> osobnicyWNastepnejPopulacji = new List<Osobnik>();
                for(int potomek = 0; potomek < liczbaOsobnikowWPopulacji; potomek++)
                {
                    Osobnik rodzic1 = selekcja.selekcjaTurniejem();
                    // Osobnik rodzic1 = selekcja.wybranyOsobnik();
                    Osobnik rodzic2 = selekcja.selekcjaTurniejem();
                    // Osobnik rodzic2 = selekcja.wybranyOsobnik();
                    Osobnik dziecko;

                    double prawdKrzyzowania = losowacz.NextDouble();
                    if (prawdKrzyzowania < prawdopodobienstwoKrzyzowania)
                    {
                        dziecko = new Osobnik(rodzic1, rodzic2);
                    }
                    else
                    {
                        dziecko = new Osobnik(rodzic1);
                    }

                    double prawdMutacji = losowacz.NextDouble();
                    if (prawdMutacji < prawdopodobienstwoMutacji)
                    {
                        dziecko.mutujSwapem();
                    }
                    osobnicyWNastepnejPopulacji.Add(dziecko);
                }

                osobnicyPopulacji = osobnicyWNastepnejPopulacji;
            }
        }

        public Osobnik znajdzNajlepszego()
        {
            Osobnik najlepszy = osobnicyPopulacji[0];
            double najlepszaFunkcja = najlepszy.funkcjaCelu();

            for (int osobnik = 1; osobnik < osobnicyPopulacji.Count; osobnik++)
            {
                double czyNajlepszaFunkcja = osobnicyPopulacji[osobnik].funkcjaCelu();
                if(czyNajlepszaFunkcja < najlepszaFunkcja)
                {
                    najlepszaFunkcja = czyNajlepszaFunkcja;
                    najlepszy = osobnicyPopulacji[osobnik];
                }
            }

            return najlepszy;
        }

    }
}
