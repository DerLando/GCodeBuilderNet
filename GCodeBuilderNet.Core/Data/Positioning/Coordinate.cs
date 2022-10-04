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

        public static Coordinate operator +(in Coordinate a) => a;
        public static Coordinate operator -(in Coordinate a) => new Coordinate(-a.X, -a.Y);
        public static Coordinate operator +(in Coordinate a, in Coordinate b) => new Coordinate(a.X + b.X, a.Y + b.Y);
        public static Coordinate operator -(in Coordinate a, in Coordinate b) => a + (-b);
    }
}
