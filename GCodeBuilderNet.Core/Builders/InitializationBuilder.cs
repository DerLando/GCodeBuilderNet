using GCodeBuilderNet.Core.Commands.General;
using GCodeBuilderNet.Core.Data.Positioning;
using System;
using System.Collections.Generic;
using System.Text;

namespace GCodeBuilderNet.Core.Builders
{
    public class InitializationBuilder
    {
        private readonly Initialization initialization;

        public InitializationBuilder()
        {
            initialization = new Initialization();
        }

        public Initialization Build()
        {
            return initialization;
        }

        public InitializationBuilder WithUnitSystem(UnitSystem unitSystem)
        {
            this.initialization.UnitSystem = unitSystem;
            return this;
        }

        public InitializationBuilder WithPlaneSystem(PlaneSystem planeSystem)
        {
            this.initialization.Plane = planeSystem;
            return this;
        }

        public InitializationBuilder WithCoordinateType(CoordinateType coordinateType)
        {
            this.initialization.CoordinateType = coordinateType;
            return this;
        }

        public InitializationBuilder WithSpeed(double speed)
        {
            this.initialization.Speed = speed;
            return this;
        }
    }
}
