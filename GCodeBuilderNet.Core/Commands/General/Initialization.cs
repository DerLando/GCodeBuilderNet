using GCodeBuilderNet.Core.Data.Positioning;
using GCodeBuilderNet.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GCodeBuilderNet.Core.Commands.General
{
    public class Initialization : IGCommand
    {
        public UnitSystem UnitSystem { get; set; }
        public CoordinateType CoordinateType { get; set; }
        public PlaneSystem Plane { get; set; }
        public double? Speed { get; set; }

        public GCommandType CommandType => throw new NotImplementedException();

        public Initialization()
        {
            UnitSystem = UnitSystem.Metric;
            CoordinateType = CoordinateType.Absolute;
            Plane = PlaneSystem.XY;
        }

        public string GetCommandText()
        {
            return $"{UnitSystem.CommandType()} {Plane.CommandType()} {CoordinateType.CommandType()} {Speed?.ToString()}";
        }
    }
}
