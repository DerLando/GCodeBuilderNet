using GCodeBuilderNet.Core.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace GCodeBuilderNet.Core.Data.Positioning.Moves
{
    internal abstract class MoveBase
    {
        public Coordinate Coordinate { get; set; }
        public CoordinateType Type { get; set; }

        protected MoveBase ()
        {
            Coordinate = Coordinate.ZERO;
            Type = CoordinateType.Absolute;
        }
    }
}
