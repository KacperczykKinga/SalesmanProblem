using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI1
{
    class Wezel
    {
        public float index { get; set; }
        public float X { get; set; }
        public float Y { get; set; }

        public Wezel(float i, float x, float y)
        {
            index = i;
            X = x;
            Y = y;
        }

        public double odlegloscDo(Wezel innyWezel)
        {
            return Math.Sqrt(Math.Pow((X - innyWezel.X), 2) + Math.Pow((Y - innyWezel.Y), 2));
        }

        public String toString()
        {
            return index+ " ";
        }
    }
}
