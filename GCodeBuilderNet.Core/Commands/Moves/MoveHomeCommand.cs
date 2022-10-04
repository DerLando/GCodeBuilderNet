using GCodeBuilderNet.Core.Data.Positioning;
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
                builder.Append($" X{IntermediateTarget.Value.X} Y{IntermediateTarget.Value.Y}");

            return builder.ToString();
        }
    }
}
