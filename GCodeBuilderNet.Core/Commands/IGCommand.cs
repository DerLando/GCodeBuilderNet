using System;
using System.Collections.Generic;
using System.Text;

namespace GCodeBuilderNet.Core.Commands
{
    public interface IGCommand
    {
        GCommandType CommandType { get; }
        string GetCommandText();
    }
}
