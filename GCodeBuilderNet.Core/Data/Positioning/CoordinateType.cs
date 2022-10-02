using System;
using System.Collections.Generic;
using System.Text;

namespace GCodeBuilderNet.Core.Data.Positioning
{
    public enum CoordinateType
    {
        /// <summary>
        /// The coordinates are absolute in plane space
        /// </summary>
        Absolute,
        /// <summary>
        /// The coordinates are relative to the last coordinate
        /// </summary>
        Relative,
        /// <summary>
        /// Whatever mode the program is in right now, use that
        /// </summary>
        Transient
    }
}
