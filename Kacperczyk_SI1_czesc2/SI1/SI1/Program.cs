using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI1
{
    class Program
    {
        String berlin11_modified = @"C:\Users\Kinga\Downloads\ai-lab1-2020-tsp_dane\TSP\berlin11_modified.tsp";
        /*String berlin52 = @"C:\Users\Kinga\Downloads\ai-lab1-2020-tsp_dane\TSP\berlin52.tsp";
        String kroA100 = @"C:\Users\Kinga\Downloads\ai-lab1-2020-tsp_dane\TSP\kroA100.tsp";
        String kroA150 = @"C:\Users\Kinga\Downloads\ai-lab1-2020-tsp_dane\TSP\kroA150.tsp";
        String kroA200 = @"C:\Users\Kinga\Downloads\ai-lab1-2020-tsp_dane\TSP\kroA200.tsp";
        String fl417 = @"C:\Users\Kinga\Downloads\ai-lab1-2020-tsp_dane\TSP\fl417.tsp";
        String nrw1379 = @"C:\Users\Kinga\Downloads\ai-lab1-2020-tsp_dane\TSP\nrw1379.tsp";
        String pr2392 = @"C:\Users\Kinga\Downloads\ai-lab1-2020-tsp_dane\TSP\pr2392.tsp";
        */
        static void Main(string[] args)
        {
            int ileProb = 100;
            int ktoryWezel = 1;

            Program program = new Program();
            Console.WriteLine("Losowy:");
            program.pokazRozwiazaniaWszystkichMiastLosowy(ileProb);
            Console.WriteLine("Zachlanny:");
            program.pokazRozwiazaniaWszystkichMiastZachlanny(ktoryWezel);

            Console.WriteLine("Genetyczny:");
            program.pokazRozwiazanieWszystkichMiastGenetyczny();
        }

        public void pokazRozwiazanieWszystkichMiastGenetyczny()
        {
            Miasto sprawdzaneMiasto = new Miasto(berlin11_modified);
            AlgorytmGenetyczny tester = new AlgorytmGenetyczny(sprawdzaneMiasto, 40, 5, 10000, 0.6, 0.2);
            tester.zrobOstatniePokolenie();
            Osobnik wybraniec = tester.znajdzNajlepszego();
            wybraniec.wypiszOsobnika();
            Console.WriteLine(wybraniec.funkcjaCelu());
        }

        public void pokazRozwiazaniaWszystkichMiastLosowy(int ileProb)
        {
            Osobnik berlin = wybierzRozwiazanieAlgorytmemLosowym(berlin11_modified, ileProb);
            berlin.wypiszOsobnika();
            Console.WriteLine(berlin.funkcjaCelu());

           /* Osobnik berlin2 = wybierzRozwiazanieAlgorytmemLosowym(berlin52, ileProb);
            berlin2.wypiszOsobnika();
            Console.WriteLine(berlin2.funkcjaCelu());

            Osobnik kroA = wybierzRozwiazanieAlgorytmemLosowym(kroA100, ileProb);
            kroA.wypiszOsobnika();
            Console.WriteLine(kroA.funkcjaCelu());

            Osobnik kroA2 = wybierzRozwiazanieAlgorytmemLosowym(kroA150, ileProb);
            kroA2.wypiszOsobnika();
            Console.WriteLine(kroA2.funkcjaCelu());

            Osobnik kroA3 = wybierzRozwiazanieAlgorytmemLosowym(kroA200, ileProb);
            kroA3.wypiszOsobnika();
            Console.WriteLine(kroA3.funkcjaCelu());

            Osobnik fl = wybierzRozwiazanieAlgorytmemLosowym(fl417, ileProb);
            fl.wypiszOsobnika();
            Console.WriteLine(fl.funkcjaCelu());

            Osobnik nrw = wybierzRozwiazanieAlgorytmemLosowym(nrw1379, ileProb);
            nrw.wypiszOsobnika();
            Console.WriteLine(nrw.funkcjaCelu());

            Osobnik pr = wybierzRozwiazanieAlgorytmemLosowym(pr2392, ileProb);
            pr.wypiszOsobnika();
            Console.WriteLine(pr.funkcjaCelu());*/
        }

        public void pokazRozwiazaniaWszystkichMiastZachlanny(int ktoryWezel)
        {
            Osobnik berlin = wybierzRozwiazanieAlgorytmemZachlannym(berlin11_modified, ktoryWezel);
            if (berlin != null)
            {
                berlin.wypiszOsobnika();
                Console.WriteLine(berlin.funkcjaCelu());
            }

           /*Osobnik berlin2 = wybierzRozwiazanieAlgorytmemZachlannym(berlin52, ktoryWezel);
            if (berlin2 != null)
            {
                berlin2.wypiszOsobnika();
                Console.WriteLine(berlin2.funkcjaCelu());
            }

            Osobnik kroA = wybierzRozwiazanieAlgorytmemZachlannym(kroA100, ktoryWezel);
            if (kroA != null)
            {
                kroA.wypiszOsobnika();
                Console.WriteLine(kroA.funkcjaCelu());
            }

            Osobnik kroA2 = wybierzRozwiazanieAlgorytmemZachlannym(kroA150, ktoryWezel);
            if (kroA2 != null)
            {
                kroA2.wypiszOsobnika();
                Console.WriteLine(kroA2.funkcjaCelu());
            }

            Osobnik kroA3 = wybierzRozwiazanieAlgorytmemZachlannym(kroA200, ktoryWezel);
            if (kroA3 != null)
            {
                kroA3.wypiszOsobnika();
                Console.WriteLine(kroA3.funkcjaCelu());
            }

            Osobnik fl = wybierzRozwiazanieAlgorytmemZachlannym(fl417, ktoryWezel);
            if (fl != null)
            {
                fl.wypiszOsobnika();
                Console.WriteLine(fl.funkcjaCelu());
            }

            Osobnik nrw = wybierzRozwiazanieAlgorytmemZachlannym(nrw1379, ktoryWezel);
            if (nrw != null)
            {
                nrw.wypiszOsobnika();
                Console.WriteLine(nrw.funkcjaCelu());
            }

            Osobnik pr = wybierzRozwiazanieAlgorytmemZachlannym(pr2392, ktoryWezel);
            if (pr != null)
            {
                pr.wypiszOsobnika();
                Console.WriteLine(pr.funkcjaCelu());
            }
            */
        }

        public static Osobnik wybierzRozwiazanieAlgorytmemLosowym(String sciezkaDoPlikuMiasta, int ileProbLosowania)
        {
            Miasto sprawdzaneMiasto = new Miasto(sciezkaDoPlikuMiasta);
            AlgorytmLosowy algorytm = new AlgorytmLosowy(ileProbLosowania, sprawdzaneMiasto);
            Osobnik najlepszyOsobnik = algorytm.najlepszyLosowy();
            return najlepszyOsobnik;
        }

        public static Osobnik wybierzRozwiazanieAlgorytmemZachlannym(String sciezkaDoPlikuMiasta, int ktoryWezel)
        {
            Miasto sprawdzaneMiasto = new Miasto(sciezkaDoPlikuMiasta);
            int liczbaWezlowWMiescie = sprawdzaneMiasto.getWezly().Count;
            if (ktoryWezel > liczbaWezlowWMiescie || ktoryWezel <= 0)
            {
                Console.WriteLine("Wybrany wezel nie znajduje sie w miescie");
                return null;
            }
            else
            {
                Osobnik jeden = new Osobnik(sprawdzaneMiasto, "ZACHLANNY", ktoryWezel - 1);
                return jeden;
            }
        }
    }
}
