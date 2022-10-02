using System;
using System.Collections.Generic;
using System.Text;

namespace GCodeBuilderNet.Core.Data.Positioning
{
    public enum UnitSystem
    {
        /// <summary>
        /// The one true way of defining units
        /// </summary>
        Metric,
        /// <summary>
        /// The other way, for backwards compability reasons
        /// </summary>
        American
    }
}
