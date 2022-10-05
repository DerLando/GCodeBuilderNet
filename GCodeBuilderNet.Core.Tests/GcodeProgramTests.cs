using GCodeBuilderNet.Core.Builders;
using GCodeBuilderNet.Core.Data.Program;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GCodeBuilderNet.Core.Tests
{
    public class GcodeProgramTests
    {
        [Test]
        public void EmptyProgramShouldBeValid()
        {

        }

        [Test]
        public void ProgramShouldWriteExpected()
        {
            //// Arrange
            //var program =
            //    new GCodeProgram()
            //    .WithCommand(new MoveRapidCommandBuilder()
                
            //        .WithTargetX(10.0)
            //        .WithTargetY(20.0)
            //        .Build())
            //    .WithCommand(new MoveLinearCommandBuilder()
            //        .WithTargetX(10.0)
            //        .WithTargetY(20.0)
            //        .WithLift(-1.0)
            //        .Build())
            //    .WithCommand(new MoveLinearCommandBuilder()
            //        .WithTargetX(40.0)
            //        .WithTargetY(20.0)
            //        .WithLift(-1.0)
            //        .Build())
            //    ;

            //// Act
            //program.Save("simple_program.gcode");
        }
    }
}
