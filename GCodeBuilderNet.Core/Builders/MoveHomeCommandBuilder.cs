using GCodeBuilderNet.Core.Commands;
using GCodeBuilderNet.Core.Commands.Moves;
using GCodeBuilderNet.Core.Data.Positioning;
using System;
using System.Collections.Generic;
using System.Text;

namespace GCodeBuilderNet.Core.Builders
{
    public class MoveHomeCommandBuilder : IMoveCommandBuilder<MoveHomeCommandBuilder>
    {
        private readonly MoveHomeCommand command;

        public MoveHomeCommandBuilder()
        {
            this.command = new MoveHomeCommand();
        }

        public IGCommand Build()
        {
            return command;
        }

        public MoveHomeCommandBuilder WithCoordinateType(CoordinateType type)
        {
            throw new NotImplementedException();
        }

        public MoveHomeCommandBuilder WithTarget(Coordinate target)
        {
            command.IntermediateTarget = target;
            return this;
        }
    }
}
