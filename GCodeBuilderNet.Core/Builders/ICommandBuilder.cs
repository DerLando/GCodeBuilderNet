using GCodeBuilderNet.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GCodeBuilderNet.Core.Builders
{
    public interface ICommandBuilder<B>
    {
        IGCommand Build();
    }
}
