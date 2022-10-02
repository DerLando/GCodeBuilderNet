using GCodeBuilderNet.Core.Commands;
using GCodeBuilderNet.Core.Data.Positioning;
using System;
using System.Collections.Generic;
using System.Text;

namespace GCodeBuilderNet.Core.Extensions
{
    internal static class DataEnumExtensions
    {
        internal static GCommandType CommandType (this CoordinateType coordinateType)
        {
            var result = GCommandType.G90;
            switch (coordinateType)
            {
                case CoordinateType.Absolute:
                    break;
                case CoordinateType.Relative:
                    result = GCommandType.G91;
                    break;
                case CoordinateType.Transient:
                    break;
                default:
                    break;
            }

            return result;
        }

        internal static GCommandType CommandType(this UnitSystem unitSystem)
        {
            GCommandType result = GCommandType.G21;

            switch (unitSystem)
            {
                case UnitSystem.Metric:
                    break;
                case UnitSystem.American:
                    result = GCommandType.G20;
                    break;
                default:
                    break;
            }

            return result;
        }

        internal static GCommandType CommandType(this PlaneSystem plane)
        {
            GCommandType result = GCommandType.G17;

            switch (plane)
            {
                case PlaneSystem.XY:
                    break;
                case PlaneSystem.XZ:
                    result = GCommandType.G18;
                    break;
                case PlaneSystem.YZ:
                    result = GCommandType.G19;
                    break;
                default:
                    break;
            }

            return result;
        }

    }
}
