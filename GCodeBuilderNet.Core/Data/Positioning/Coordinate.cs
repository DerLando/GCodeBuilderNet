using System;
using System.Collections.Generic;
using System.Text;

namespace GCodeBuilderNet.Core.Data.Positioning
{
    public readonly struct Coordinate
    {
        public readonly double X;
        public readonly double Y;

        private static Coordinate zero = new Coordinate(0, 0);
        public static ref readonly Coordinate ZERO => ref zero;

        public Coordinate(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
