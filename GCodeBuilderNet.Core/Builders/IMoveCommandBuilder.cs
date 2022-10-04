using GCodeBuilderNet.Core.Data.Positioning;
using System;
using System.Collections.Generic;
using System.Text;

namespace GCodeBuilderNet.Core.Builders
{
    public interface IMoveCommandBuilder<Builder> : ICommandBuilder<Builder>
    {
        Builder WithTarget(Coordinate target);
        Builder WithCoordinateType(CoordinateType type);
    }
}
