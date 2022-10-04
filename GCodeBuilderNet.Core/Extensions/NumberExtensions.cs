using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace GCodeBuilderNet.Core.Extensions
{
    internal static class NumberExtensions
    {
        internal static string ToGCode(this double num)
        {
            return Math.Round(num, 3).ToString(CultureInfo.InvariantCulture);
        }
    }
}
