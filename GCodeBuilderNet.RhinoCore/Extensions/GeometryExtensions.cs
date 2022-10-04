using GCodeBuilderNet.Core.Data.Positioning;
using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCodeBuilderNet.RhinoCore.Extensions
{
    internal static class GeometryExtensions
    {
        internal static Point3d ToPoint3d(in this Coordinate coordinate)
        {
            return new Point3d(coordinate.X, coordinate.Y, 0.0);
        }

        internal static Coordinate ToCoordinate(this Point3d pt)
        {
            return new Coordinate(pt.X, pt.Y);
        }
    }
}
