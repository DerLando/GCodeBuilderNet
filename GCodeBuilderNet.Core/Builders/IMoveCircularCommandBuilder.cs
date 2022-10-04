using GCodeBuilderNet.Core.Data.Positioning;
using System;
using System.Collections.Generic;
using System.Text;

namespace GCodeBuilderNet.Core.Builders
{
    public interface IMoveCircularCommandBuilder<Builder> : IMoveLinearCommandBuilder<Builder>
    {
        Builder WithCenterX(double centerX);
        Builder WithCenterY(double centerY);
        Builder WithDirection(ArcDirection direction);
    }
}
