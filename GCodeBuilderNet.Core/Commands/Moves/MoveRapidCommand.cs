using GCodeBuilderNet.Core.Data.Positioning.Moves;
using GCodeBuilderNet.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GCodeBuilderNet.Core.Commands.Moves
{
    internal class MoveRapidCommand : IGCommand
    {
        public GCommandType CommandType => GCommandType.G00;

        private MoveRapid move;

        public MoveRapidCommand(MoveRapid move)
        {
            this.move = move;
        }

        public string GetCommandText()
        {
            return $"{CommandType} X{move.Target.X.ToGCode()} Y{move.Target.Y.ToGCode()}";
        }
    }
}
