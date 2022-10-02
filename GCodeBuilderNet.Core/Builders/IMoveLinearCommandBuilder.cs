using System;
using System.Collections.Generic;
using System.Text;

namespace GCodeBuilderNet.Core.Builders
{
    public interface IMoveLinearCommandBuilder<Builder> : IMoveCommandBuilder<Builder>
    {
        Builder WithSpeed(double speed);
        Builder WithLift(double lift);
    }
}
