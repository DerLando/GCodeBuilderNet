using GCodeBuilderNet.Core.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace GCodeBuilderNet.Core.Data.Positioning.Moves
{
    internal abstract class MoveBase
    {
        public Coordinate Target { get; set; } = Coordinate.ZERO;
        public CoordinateType Type { get; set; } = CoordinateType.Absolute;

        protected MoveBase ()
        {
        }
    }
}
