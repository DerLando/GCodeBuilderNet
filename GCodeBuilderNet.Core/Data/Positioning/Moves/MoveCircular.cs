using System;
using System.Collections.Generic;
using System.Text;

namespace GCodeBuilderNet.Core.Data.Positioning.Moves
{
    internal class MoveCircular : MoveLinear
    {
        public Coordinate Center { get; set; } = Coordinate.ZERO;
        public ArcDirection Direction { get; set; } = ArcDirection.CounterClockwise;
    }
}
