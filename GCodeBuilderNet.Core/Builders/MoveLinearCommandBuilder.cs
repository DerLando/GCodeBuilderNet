using GCodeBuilderNet.Core.Commands;
using GCodeBuilderNet.Core.Commands.Moves;
using GCodeBuilderNet.Core.Data.Positioning;
using GCodeBuilderNet.Core.Data.Positioning.Moves;
using System;
using System.Collections.Generic;
using System.Text;

namespace GCodeBuilderNet.Core.Builders
{
    public class MoveLinearCommandBuilder : IMoveLinearCommandBuilder<MoveLinearCommandBuilder>
    {
        private readonly MoveLinear move;

        public MoveLinearCommandBuilder()
        {
            move = new MoveLinear();
        }

        public IGCommand Build()
        {
            return new MoveLinearCommand(move);
        }

        public MoveLinearCommandBuilder WithCoordinateType(CoordinateType type)
        {
            move.Type = type;
            return this;
        }

        public MoveLinearCommandBuilder WithLift(double lift)
        {
            move.Lift = lift;
            return this;
        }

        public MoveLinearCommandBuilder WithSpeed(double speed)
        {
            move.Speed = speed;
            return this;
        }

        public MoveLinearCommandBuilder WithTargetX(double x)
        {
            move.Target = new Coordinate(x, move.Target.Y);
            return this;
        }

        public MoveLinearCommandBuilder WithTargetY(double y)
        {
            move.Target = new Coordinate(move.Target.X, y);
            return this;
        }
    }
}
