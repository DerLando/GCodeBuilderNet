using GCodeBuilderNet.Core.Commands;
using GCodeBuilderNet.Core.Commands.Moves;
using GCodeBuilderNet.Core.Data.Positioning;
using GCodeBuilderNet.Core.Data.Positioning.Moves;
using System;
using System.Collections.Generic;
using System.Text;

namespace GCodeBuilderNet.Core.Builders
{
    public class MoveRapidCommandBuilder : IMoveCommandBuilder<MoveRapidCommandBuilder>
    {
        private readonly MoveRapid move;

        public MoveRapidCommandBuilder()
        {
            move = new MoveRapid();
        }

        public IGCommand Build()
        {
            return new MoveRapidCommand(move);
        }

        public MoveRapidCommandBuilder WithCoordinateType(CoordinateType type)
        {
            move.Type = type;
            return this;
        }

        public MoveRapidCommandBuilder WithTargetX(double x)
        {
            move.Target = new Coordinate(x, move.Target.Y);
            return this;
        }

        public MoveRapidCommandBuilder WithTargetY(double y)
        {
            move.Target = new Coordinate(move.Target.X, y);
            return this;
        }
    }
}
