using GCodeBuilderNet.Core.Data.Positioning.Moves;
using GCodeBuilderNet.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GCodeBuilderNet.Core.Commands.Moves
{
    internal class MoveCircularCommand : IGCommand
    {
        private MoveCircular move;

        public MoveCircularCommand(MoveCircular move)
        {
            this.move = move;
        }

        public GCommandType CommandType => move.Direction.CommandType();

        public string GetCommandText()
        {
            var builder = new StringBuilder();
            builder.Append(CommandType);
            builder.Append($" X{move.Target.X.ToGCode()}");
            builder.Append($" Y{move.Target.Y.ToGCode()}");
            builder.Append($" Z{move.Lift.ToGCode()}");
            builder.Append($" I{(move.Target - move.Center).X.ToGCode()}");
            builder.Append($" J{(move.Target - move.Center).Y.ToGCode()}");
            if (move.Speed.HasValue)
                builder.Append($" F{move.Speed.Value.ToGCode()}");

            return builder.ToString();
        }
    }
}
