using GCodeBuilderNet.Core.Data.Positioning;
using System;
using System.Collections.Generic;
using System.Text;

namespace GCodeBuilderNet.Core.Builders
{
    public interface IMoveCommandBuilder<Builder> : ICommandBuilder<Builder>
    {
        Builder WithX(double x);
        Builder WithY(double y);
        Builder WithCoordinateType(CoordinateType type);
    }
}
