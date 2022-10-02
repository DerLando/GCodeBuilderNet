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
            return $"{CommandType} X{move.Target.X} Y{move.Target.Y} Z{move.Lift} I{move.Center.X} J{move.Center.Y} {((move.Speed is null)? $"F{move.Speed}" : "")}";
        }
    }
}
