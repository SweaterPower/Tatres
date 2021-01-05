using System;
using System.Collections.Generic;
using System.Text;

namespace Tatres
{
    class Point
    {
        int x;
        int y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public override string ToString()
        {
            return "X: " + x + " Y: " + y;
        }
    }
}
