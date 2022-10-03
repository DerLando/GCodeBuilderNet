using GCodeBuilderNet.Core.Builders;
using GCodeBuilderNet.Core.Data.Program;
using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCodeBuilderNet.Rhino.Core.Converters
{
    internal static class PolyCurveConverter
    {
        internal static GCodeProgram Convert(PolyCurve curve)
        {
            var program =
                new GCodeProgram()
                .WithCommand(new MoveRapidCommandBuilder()
                    .WithTargetX(curve.PointAtStart.X)
                    .WithTargetY(curve.PointAtStart.Y)
                    .Build())
                .WithCommand(new MoveLinearCommandBuilder()
                    .WithTargetX(curve.PointAtStart.X)
                    .WithTargetY(curve.PointAtStart.Y)
                    .WithLift(-1.0)
                    .Build())
                ;

            foreach (var segment in curve.DuplicateSegments())
            {
                if(segment is LineCurve)
                {
                    program.WithCommand(new MoveLinearCommandBuilder()
                        .WithTargetX(segment.PointAtEnd.X)
                        .WithTargetY(segment.PointAtEnd.Y)
                        .WithLift(-1.0)
                        .Build());
                    continue;
                }

                if (segment is ArcCurve arc)
                {
                    // TODO: How to find out the arc direction, cw/ccw?
                    program.WithCommand(new MoveCircularCommandBuilder()
                        .WithCenterX(arc.Arc.Center.X)
                        .WithCenterY(arc.Arc.Center.Y)
                        .WithTargetX(arc.PointAtEnd.X)
                        .WithTargetY(arc.PointAtEnd.Y)
                        .WithLift(-1.0)
                        .Build());
                    continue;
                }
            }

            return program;
        }
    }
}
