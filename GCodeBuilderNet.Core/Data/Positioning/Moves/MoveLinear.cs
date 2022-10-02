using System;
using System.Collections.Generic;
using System.Text;

namespace GCodeBuilderNet.Core.Data.Positioning.Moves
{
    internal class MoveLinear : MoveBase
    {
        public double Lift { get; set; }
        public double Speed { get; set; }
    }
}
