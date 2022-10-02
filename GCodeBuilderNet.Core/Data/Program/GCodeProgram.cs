using GCodeBuilderNet.Core.Commands;
using GCodeBuilderNet.Core.Commands.General;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GCodeBuilderNet.Core.Data.Program
{
    public class GCodeProgram
    {
        private const string PROGRAM_NAME = "GCBN";
        private const string EXTENSION = ".gcode";

        private Initialization initialization = new Initialization();
        private List<IGCommand> commands = new List<IGCommand>();

        private string BuildProgramString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("%");
            builder.AppendLine($"O{PROGRAM_NAME}");

            // Write initializations
            builder.AppendLine(initialization.GetCommandText());

            foreach (var command in commands)
            {
                builder.AppendLine(command.GetCommandText());
            }

            builder.AppendLine("%");

            return builder.ToString();
        }

        public GCodeProgram Initialize(Initialization initialization)
        {
            this.initialization = initialization;
            return this;
        }

        public GCodeProgram WithCommand(IGCommand command)
        {
            this.commands.Add(command);
            return this;
        }

        public string Dump()
        {
            return BuildProgramString();
        }

        public void Save(string filename)
        {
            if(Path.GetExtension(filename) != EXTENSION)
                return;

            File.WriteAllText(filename, Dump());
        }
    }
}
