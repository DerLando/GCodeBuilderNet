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
    public static class CurveConverter
    {
        public static string ConvertToGCode(IEnumerable<Curve> curves)
        {
            return Convert(curves).Dump();
        }

        public static GCodeProgram Convert(IEnumerable<Curve> curves)
        {
            var program = new GCodeProgram();

            foreach (var crv in curves)
            {
                //// Only planar crvs please
                //if (!crv.TryGetPlane(out var plane, 0.01))
                //    continue;

                if(crv is LineCurve line)
                {
                    program.Append(line);
                    continue;
                }
                if(crv is ArcCurve arc)
                {
                    program.Append(arc);
                    continue;
                }
                if(crv is PolyCurve poly)
                {
                    program.Append(poly);
                    continue;
                }
                if(crv is PolylineCurve pline)
                {
                    program.Append(pline);
                    continue;
                }

                Rhino.RhinoApp.WriteLine($"Failed to convert curve {crv}");

            }

            return program;
        }

        internal static void Append(this GCodeProgram program, PolylineCurve crv, bool moveTo = true)
        {
            if (moveTo)
            {
                program
                    .WithCommand(new MoveLinearCommandBuilder()
                        .WithTarget(crv.PointAtStart.ToCoordinate())
                        .WithLift(crv.PointAtStart.Z)
                        .WithSpeed(200)
                        .Build());
            }

            foreach (LineCurve segment in crv.DuplicateSegments())
            {
                program.Append(segment, false);
            }
        }

        internal static void Append(this GCodeProgram program, PolyCurve crv, bool moveTo = true)
        {
            if(moveTo)
            {
                program
                    .WithCommand(new MoveLinearCommandBuilder()
                        .WithTarget(crv.PointAtStart.ToCoordinate())
                        .WithLift(crv.PointAtStart.Z)
                        .WithSpeed(200)
                        .Build());
            }

            foreach (var segment in crv.DuplicateSegments())
            {
                if (segment is ArcCurve arc)
                {
                    program.Append(arc, false);
                    continue;
                }
                if (segment is LineCurve line)
                {
                    program.Append(line, false);
                    continue;
                }
                if (segment is PolyCurve poly)
                {
                    program.Append(poly);
                    continue;
                }
            }
        }

        internal static void Append(this GCodeProgram program, LineCurve crv, bool moveTo = true)
        {
            if(moveTo)
            {
                program
                    .WithCommand(new MoveLinearCommandBuilder()
                        .WithTarget(crv.Line.From.ToCoordinate())
                        .WithLift(crv.Line.From.Z)
                        .WithSpeed(200)
                        .Build());
            }

            program
                .WithCommand(new MoveLinearCommandBuilder()
                    .WithTarget(crv.Line.To.ToCoordinate())
                    .WithLift(crv.Line.To.Z)
                    .WithSpeed(10)
                    .Build());
        }

        internal static void Append(this GCodeProgram program, ArcCurve arc, bool moveTo = true)
        {
            ArcDirection direction;
            if (arc.Arc.Plane.ZAxis.IsParallelTo(Vector3d.ZAxis) == 1)
                direction = ArcDirection.CounterClockwise;
            else
                direction = ArcDirection.Clockwise;

            if(moveTo)
            {
                program
                    .WithCommand(new MoveLinearCommandBuilder()
                        .WithTarget(arc.PointAtStart.ToCoordinate())
                        .WithLift(arc.PointAtStart.Z)
                        .WithSpeed(200)
                        .Build());
            }
            program
                .WithCommand(new MoveCircularCommandBuilder()
                    .WithTarget(arc.PointAtEnd.ToCoordinate())
                    .WithCenter(ArcRelativeCenter(arc))
                    .WithLift(arc.PointAtEnd.Z)
                    .WithDirection(direction)
                    .WithSpeed(10)
                    .Build());
        }

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
                        .WithCenter(ArcRelativeCenter(arc))
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

        internal static Coordinate ArcRelativeCenter(ArcCurve arc)
        {
            return new Point3d(arc.Arc.Center - arc.PointAtStart).ToCoordinate();
        }
    }
}
