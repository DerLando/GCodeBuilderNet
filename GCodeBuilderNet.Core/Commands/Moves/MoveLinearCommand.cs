using GCodeBuilderNet.Core.Data.Positioning.Moves;
using GCodeBuilderNet.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GCodeBuilderNet.Core.Commands.Moves
{
    internal class MoveLinearCommand : IGCommand
    {
        public GCommandType CommandType => GCommandType.G01;

        private MoveLinear move;

        public MoveLinearCommand(MoveLinear move)
        {
            this.move = move;
        }

        public string GetCommandText()
        {
            var builder = new StringBuilder();
            builder.Append(CommandType);
            builder.Append($" X{move.Target.X.ToGCode()}");
            builder.Append($" Y{move.Target.Y.ToGCode()}");
            builder.Append($" Z{move.Lift.ToGCode()}");
            if (move.Speed.HasValue)
                builder.Append($" F{move.Speed.Value.ToGCode()}");

            return builder.ToString();
        }
    }
}
