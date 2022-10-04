using GCodeBuilderNet.Core.Data.Positioning;
using System;
using System.Collections.Generic;
using System.Text;

namespace GCodeBuilderNet.Core.Builders
{
    public interface IMoveCircularCommandBuilder<Builder> : IMoveLinearCommandBuilder<Builder>
    {
        Builder WithCenter(Coordinate center);
        Builder WithDirection(ArcDirection direction);
    }
}
