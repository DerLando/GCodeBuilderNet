using GCodeBuilderNet.Core.Builders;
using GCodeBuilderNet.Core.Data.Positioning;
using GCodeBuilderNet.Core.Data.Program;
using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCodeBuilderNet.RhinoCore.Converters
{
    public static class PolyCurveConverter
    {
        public static GCodeProgram Convert(PolyCurve curve)
        {
            // Only planar curves please...
            if (!curve.TryGetPlane(out var plane))
                return null;

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
                    ArcDirection direction;
                    if (arc.Arc.Plane.ZAxis.IsParallelTo(plane.ZAxis) != 1)
                        direction = ArcDirection.Clockwise;
                    else
                        direction = ArcDirection.CounterClockwise;

                    program.WithCommand(new MoveCircularCommandBuilder()
                        .WithCenterX(arc.Arc.Center.X)
                        .WithCenterY(arc.Arc.Center.Y)
                        .WithTargetX(arc.PointAtEnd.X)
                        .WithTargetY(arc.PointAtEnd.Y)
                        .WithLift(-1.0)
                        .WithDirection(direction)
                        .Build());
                    continue;
                }
            }

            return program;
        }
    }
}
