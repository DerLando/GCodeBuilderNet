using GCodeBuilderNet.Core.Data.Positioning;
using GCodeBuilderNet.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GCodeBuilderNet.Core.Commands.Moves
{
    internal class MoveHomeCommand : IGCommand
    {
        public GCommandType CommandType => GCommandType.G28;
        public Coordinate? IntermediateTarget { get; set; }

        public string GetCommandText()
        {
            var builder = new StringBuilder();
            builder.Append(CommandType);
            if (IntermediateTarget.HasValue)
                _ = builder.Append($" X{IntermediateTarget.Value.X.ToGCode()} Y{IntermediateTarget.Value.Y.ToGCode()}");

            return builder.ToString();
        }
    }
}
