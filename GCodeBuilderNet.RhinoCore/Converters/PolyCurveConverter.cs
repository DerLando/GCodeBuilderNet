using GCodeBuilderNet.Core.Builders;
using GCodeBuilderNet.Core.Data.Positioning;
using GCodeBuilderNet.Core.Data.Program;
using GCodeBuilderNet.RhinoCore.Extensions;
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
                    .WithTarget(curve.PointAtStart.ToCoordinate())
                    .Build())
                .WithCommand(new MoveLinearCommandBuilder()
                    .WithTarget(curve.PointAtStart.ToCoordinate())
                    .WithLift(-1.0)
                    .Build())
                ;

            foreach (var segment in curve.DuplicateSegments())
            {
                if(segment is LineCurve)
                {
                    program.WithCommand(new MoveLinearCommandBuilder()
                        .WithTarget(segment.PointAtEnd.ToCoordinate())
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
                        .WithCenter(arc.Arc.Plane.Origin.ToCoordinate())
                        .WithTarget(arc.PointAtEnd.ToCoordinate())
                        .WithLift(-1.0)
                        .WithDirection(direction)
                        .Build());
                    continue;
                }
            }

            program.WithCommand(new MoveHomeCommandBuilder()
                .WithTarget(curve.PointAtEnd.ToCoordinate())
                .Build());

            return program;
        }
    }
}
