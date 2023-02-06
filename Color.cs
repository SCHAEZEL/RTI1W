using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RTI1W
{
    public class Color
    {
        public static Color White = new Color(1, 1, 1);
        public static Color Red = new Color(1, 0, 0);
        public static Color Black = new Color(0,0,0);

        public float R { get; private set; }
        public float G { get; private set; }
        public float B { get; private set; }

        public Color()
        {
            this.R = 0;
            this.G = 0;
            this.B = 0;
        }
        public Color(float _r, float _g, float _b)
        {
            this.R = _r;
            this.G = _g;
            this.B = _b;
        }

        public static Color operator *(float left, Color right)
        {
            Color retCol = new Color(left * right.R, left * right.G, left * right.B);
            return retCol;
        }

        public static Color operator +(Color left, Color right)
        {
            Color retCol = new Color(left.R + right.R, left.G + right.G, left.B + right.B);
            return retCol;
        }
    }
}