using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI1
{
    class Osobnik
    {
        List<Wezel> kolejnoscOdwiedzaniaWezlow = new List<Wezel>();
        static Random losowacz = new Random();

        public Osobnik(Miasto miasto, String sposob, int poczatkowyWezel = 0)
        {
            List<Wezel> wezlyMiasta = miasto.getWezly();
            if(sposob == "LOSOWY")
            {
                tworzOsobnikaLosowo(wezlyMiasta);
            }
            else if (sposob == "ZACHLANNY")
            {
                tworzOsobnikaZachlannie(wezlyMiasta, poczatkowyWezel);
            }
        }

        public Osobnik(Osobnik rodzic1, Osobnik rodzic2)
        {
            operatorKrzyzowaniaOX(rodzic1, rodzic2);
        }

        public Osobnik(Osobnik doSklonowania)
        {
            foreach (Wezel gen in doSklonowania.kolejnoscOdwiedzaniaWezlow)
            {
                kolejnoscOdwiedzaniaWezlow.Add(gen);
            }
        }

        public void operatorKrzyzowaniaOX(Osobnik rodzic1, Osobnik rodzic2)
        {
            int poczatek = losowacz.Next(0, rodzic1.kolejnoscOdwiedzaniaWezlow.Count);
            int koniec = losowacz.Next(poczatek + 1, rodzic1.kolejnoscOdwiedzaniaWezlow.Count);
           // Console.WriteLine(poczatek + "   " + koniec);

            List<Wezel> doPrzekopiowaniaZPierwszego = new List<Wezel>();
            for (int kopiuj = poczatek; kopiuj < koniec; kopiuj++)
            {
                doPrzekopiowaniaZPierwszego.Add(rodzic1.kolejnoscOdwiedzaniaWezlow[kopiuj]);
            }

            int odDrugiegoRodzica = 0;
            int drugiRodzic = 0;
            while(odDrugiegoRodzica < poczatek)
            {
                //Console.WriteLine(drugiRodzic);
                if(!doPrzekopiowaniaZPierwszego.Contains(rodzic2.kolejnoscOdwiedzaniaWezlow[drugiRodzic]))
                {
                    kolejnoscOdwiedzaniaWezlow.Add(rodzic2.kolejnoscOdwiedzaniaWezlow[drugiRodzic]);
                    odDrugiegoRodzica++;
                }
                drugiRodzic++;
            }

            for(int pierwszyRodzic = 0; pierwszyRodzic < doPrzekopiowaniaZPierwszego.Count; pierwszyRodzic++)
            {
                kolejnoscOdwiedzaniaWezlow.Add(doPrzekopiowaniaZPierwszego[pierwszyRodzic]);
            }

            while(drugiRodzic < rodzic2.kolejnoscOdwiedzaniaWezlow.Count)
            {
                if(!doPrzekopiowaniaZPierwszego.Contains(rodzic2.kolejnoscOdwiedzaniaWezlow[drugiRodzic]))
                {
                    kolejnoscOdwiedzaniaWezlow.Add(rodzic2.kolejnoscOdwiedzaniaWezlow[drugiRodzic]);
                }
                drugiRodzic++;
            }           
        }

        public void tworzOsobnikaLosowo(List<Wezel> wezlyMiasta)
        {
            List<int> wezlyDopuszczoneDoLosowania = new List<int>();
            for(int wezel = 0; wezel < wezlyMiasta.Count; wezel ++)
            {
                wezlyDopuszczoneDoLosowania.Add(wezel);
            }

            while (wezlyDopuszczoneDoLosowania.Count > 0)
            {
                int losowyWezel = losowacz.Next(0, wezlyDopuszczoneDoLosowania.Count );
                kolejnoscOdwiedzaniaWezlow.Add(wezlyMiasta[wezlyDopuszczoneDoLosowania[losowyWezel]]);
                wezlyDopuszczoneDoLosowania.RemoveAt(losowyWezel);
            }
        }

        public void tworzOsobnikaZachlannie(List<Wezel> wezlyMiasta, int poczatkowyWezel)
        {
            List<int> wezlyDopuszczoneDoWybrania = new List<int>();
            for (int wezel = 0; wezel < wezlyMiasta.Count; wezel++)
            {
                wezlyDopuszczoneDoWybrania.Add(wezel);
            }

            kolejnoscOdwiedzaniaWezlow.Add(wezlyMiasta[poczatkowyWezel]);
            wezlyDopuszczoneDoWybrania.RemoveAt(poczatkowyWezel);

            while (kolejnoscOdwiedzaniaWezlow.Count < wezlyMiasta.Count)
            {
                int zachlannieNajlepszy = 0;
                double odlegloscDoZachlannieNajlepszego = kolejnoscOdwiedzaniaWezlow[kolejnoscOdwiedzaniaWezlow.Count - 1].odlegloscDo(wezlyMiasta[wezlyDopuszczoneDoWybrania[zachlannieNajlepszy]]);

                for (int krok = 1; krok < wezlyDopuszczoneDoWybrania.Count; krok++)
                {
                    double odlegloscDoCzyZachlannieNajlepszego = kolejnoscOdwiedzaniaWezlow[kolejnoscOdwiedzaniaWezlow.Count - 1].odlegloscDo(wezlyMiasta[wezlyDopuszczoneDoWybrania[krok]]);
                    if (odlegloscDoCzyZachlannieNajlepszego < odlegloscDoZachlannieNajlepszego)
                    {
                        odlegloscDoZachlannieNajlepszego = odlegloscDoCzyZachlannieNajlepszego;
                        zachlannieNajlepszy = krok;
                    }
                }

                kolejnoscOdwiedzaniaWezlow.Add(wezlyMiasta[wezlyDopuszczoneDoWybrania[zachlannieNajlepszy]]);
                wezlyDopuszczoneDoWybrania.RemoveAt(zachlannieNajlepszy);
            }
        }

        public double funkcjaCelu()
        {
            double cel = 0;
            for(int wezel = 0; wezel < kolejnoscOdwiedzaniaWezlow.Count - 1; wezel ++)
            {
                cel += kolejnoscOdwiedzaniaWezlow[wezel].odlegloscDo(kolejnoscOdwiedzaniaWezlow[wezel + 1]);
            }
            cel += kolejnoscOdwiedzaniaWezlow[kolejnoscOdwiedzaniaWezlow.Count - 1].odlegloscDo(kolejnoscOdwiedzaniaWezlow[0]);
            return cel;
        }

        public void wypiszOsobnika()
        {
            kolejnoscOdwiedzaniaWezlow.ForEach(x => Console.Write(x.toString()));
        }

        public void mutujSwapem()
        {
            int pierwszyDoZamiany = losowacz.Next(0, kolejnoscOdwiedzaniaWezlow.Count);
            int drugiDoZmiany = losowacz.Next(0, kolejnoscOdwiedzaniaWezlow.Count);
           // Console.WriteLine(pierwszyDoZamiany + "   " + drugiDoZmiany + "   ");

            Wezel tymaczsowy = kolejnoscOdwiedzaniaWezlow[pierwszyDoZamiany];
            kolejnoscOdwiedzaniaWezlow[pierwszyDoZamiany] = kolejnoscOdwiedzaniaWezlow[drugiDoZmiany];
            kolejnoscOdwiedzaniaWezlow[drugiDoZmiany] = tymaczsowy;
        }
    }
}
