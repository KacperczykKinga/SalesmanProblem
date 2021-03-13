using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SI1
{
    class AlgorytmLosowy
    {
        int liczbaPowtorzenLosowania;
        Miasto miastoDoZwiedzenia;

        public AlgorytmLosowy(int powtorzeniaLosowania, Miasto miasto)
        {
            liczbaPowtorzenLosowania = powtorzeniaLosowania;
            miastoDoZwiedzenia = miasto;
        }

        public Osobnik najlepszyLosowy()
        {
            Osobnik najlepszy = new Osobnik(miastoDoZwiedzenia, "LOSOWY");
            double funkcjaNajlepszego = najlepszy.funkcjaCelu();
            for(int i = 1; i < liczbaPowtorzenLosowania; i++)
            {
                Osobnik czyNajlepszy = new Osobnik(miastoDoZwiedzenia, "LOSOWY");
                double funkcjaCzyNajlepszego = czyNajlepszy.funkcjaCelu();

                //Console.WriteLine(i);
                //czyNajlepszy.wypiszOsobnika();
                //Console.WriteLine(funkcjaCzyNajlepszego);

                if (funkcjaCzyNajlepszego < funkcjaNajlepszego)
                {
                    najlepszy = czyNajlepszy;
                    funkcjaNajlepszego = funkcjaCzyNajlepszego;
                }

            }
            return najlepszy;
        }
    }
}
