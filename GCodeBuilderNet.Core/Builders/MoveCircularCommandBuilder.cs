using GCodeBuilderNet.Core.Commands;
using GCodeBuilderNet.Core.Commands.Moves;
using GCodeBuilderNet.Core.Data.Positioning;
using GCodeBuilderNet.Core.Data.Positioning.Moves;
using System;
using System.Collections.Generic;
using System.Text;

namespace GCodeBuilderNet.Core.Builders
{
    public class MoveCircularCommandBuilder : IMoveCircularCommandBuilder<MoveCircularCommandBuilder>
    {
        private readonly MoveCircular move;

        public MoveCircularCommandBuilder()
        {
            this.move = new MoveCircular();
        }

        public IGCommand Build()
        {
            return new MoveCircularCommand(move);
        }

        public MoveCircularCommandBuilder WithCenter(Coordinate center)
        {
            this.move.Center = center;
            return this;
        }

        public MoveCircularCommandBuilder WithCoordinateType(CoordinateType type)
        {
            this.move.Type = type;
            return this;
        }

        public MoveCircularCommandBuilder WithDirection(ArcDirection direction)
        {
            this.move.Direction = direction;
            return this;
        }

        public MoveCircularCommandBuilder WithLift(double lift)
        {
            this.move.Lift = lift;
            return this;
        }

        public MoveCircularCommandBuilder WithSpeed(double speed)
        {
            this.move.Speed = speed;
            return this;
        }

        public MoveCircularCommandBuilder WithTarget(Coordinate target)
        {
            this.move.Target = target;
            return this;
        }
    }
}
