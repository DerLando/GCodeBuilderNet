using System;
using System.Collections.Generic;
using System.Text;

namespace GCodeBuilderNet.Core.Data.Positioning.Moves
{
    internal class MoveLinear : MoveBase
    {
        public double Lift { get; set; } = 0.0;
        public double? Speed { get; set; } = null;
    }
}
