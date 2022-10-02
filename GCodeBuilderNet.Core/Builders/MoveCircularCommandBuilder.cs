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

        public IGCommand Build()
        {
            return new MoveCircularCommand(move);
        }

        public MoveCircularCommandBuilder WithCenterX(double centerX)
        {
            this.move.Center = new Coordinate(centerX, this.move.Center.Y);
            return this;
        }

        public MoveCircularCommandBuilder WithCenterY(double centerY)
        {
            this.move.Center = new Coordinate(this.move.Center.X, y);
            return this;
        }

        public MoveCircularCommandBuilder WithCoordinateType(CoordinateType type)
        {
            this.move.Type = type;
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

        public MoveCircularCommandBuilder WithTargetX(double x)
        {
            this.move.Target = new Coordinate(x, this.move.Target.Y);
            return this;
        }

        public MoveCircularCommandBuilder WithTargetY(double y)
        {
            this.move.Target = new Coordinate(this.move.Target.X, y);
            return this;
        }
    }
}
