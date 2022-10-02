using GCodeBuilderNet.Core.Data.Positioning.Moves;
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
            return $"{CommandType} X{move.Target.X} Y{move.Target.Y} Z{move.Lift} F{move.Speed}";
        }
    }
}
