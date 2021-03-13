using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI1
{
    class Miasto
    {
        List<Wezel> wezlyWMiescie;

        public Miasto(String plikZDanymiMiasta)
        {
            String miasto = Czytacz.czytajZPliku(plikZDanymiMiasta);
            wezlyWMiescie = Czytacz.stworzWezlyMiasta(miasto);
        }

        public List<Wezel> getWezly()
        {
            return wezlyWMiescie;
        }
    }
}
