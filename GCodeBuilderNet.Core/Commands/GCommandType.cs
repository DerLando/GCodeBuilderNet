﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GCodeBuilderNet.Core.Commands
{
    public enum GCommandType
    {
        /// <summary>
        /// Rapid Positioning
        /// </summary>
        G00,
        /// <summary>
        /// Linear Interpolation
        /// </summary>
        G01,
        /// <summary>
        /// Circular Interpolation CW
        /// </summary>
        G02,
        /// <summary>
        /// Circular Interpolation CCW
        /// </summary>
        G03,
        /// <summary>
        /// Plane XY
        /// </summary>
        G17,
        /// <summary>
        /// Plane XZ
        /// </summary>
        G18,
        /// <summary>
        /// Plane YZ
        /// </summary>
        G19,
        /// <summary>
        /// Units in inches
        /// </summary>
        G20,
        /// <summary>
        /// Units in mm
        /// </summary>
        G21,
        /// <summary>
        /// Move to home position
        /// </summary>
        G28,
        /// <summary>
        /// Absolute coordinates
        /// </summary>
        G90,
        /// <summary>
        /// Relative coordinates
        /// </summary>
        G91,
    }
}
