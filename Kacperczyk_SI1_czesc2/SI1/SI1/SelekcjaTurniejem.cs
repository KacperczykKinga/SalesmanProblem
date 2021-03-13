using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI1
{
    class SelekcjaTurniejem
    {
        int NosobinkowWTurnieju;
        List<Osobnik> osobnicyPopulacji = new List<Osobnik>();

        public SelekcjaTurniejem(int NOsobnikow, List<Osobnik> osobnicy )
        {
            NosobinkowWTurnieju = NOsobnikow;
            osobnicyPopulacji = osobnicy;
        }

        public Osobnik selekcjaTurniejem()
        {
            Random losowaczDoTurnieju = new Random();

            Osobnik najlepszyZTurnieju = osobnicyPopulacji[losowaczDoTurnieju.Next(osobnicyPopulacji.Count)];
            double najlepszaFunkcja = najlepszyZTurnieju.funkcjaCelu();
            //Console.WriteLine(najlepszaFunkcja);

            for (int turniej = 1; turniej < NosobinkowWTurnieju; turniej++)
            {
                int indeksWylosowanegoDoTurnieju = losowaczDoTurnieju.Next(osobnicyPopulacji.Count);
                double czyNajlepszeFuncja = osobnicyPopulacji[indeksWylosowanegoDoTurnieju].funkcjaCelu();
               // Console.WriteLine(czyNajlepszeFuncja);

                if (czyNajlepszeFuncja < najlepszaFunkcja)
                {
                    najlepszyZTurnieju = osobnicyPopulacji[indeksWylosowanegoDoTurnieju];
                    najlepszaFunkcja = czyNajlepszeFuncja;

                }
            }

            //Console.WriteLine("najlepszy z turnieju" + najlepszaFunkcja);
            return najlepszyZTurnieju;
        }
    }
}
