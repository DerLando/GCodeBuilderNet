using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RhinoInside;
using Rhino.Runtime.InProcess;
using System.IO;
using Rhino.Geometry;
using GCodeBuilderNet.RhinoCore.Converters;

namespace r2g
{
    internal class Program
    {
        static Program()
        {
            RhinoInside.Resolver.Initialize();
        }

        public class Options
        {
            [Option('i', "input", Required = true, HelpText = "The path to the input .3dm file")]
            public string Input { get; set; }
            [Option('o', "output", Required = false, HelpText = "The path to the output .gcode file. If not given, the input file name will be used.")]
            public string Output { get; set; }
        }

        [STAThread]
        static void Main(string[] args)
        {

            Parser.Default
                .ParseArguments<Options>(args)
                .WithParsed<Options>(o =>
                {
                    // Check arguments
                    if(Path.GetExtension(o.Input) != ".3dm")
                    {
                        Console.WriteLine($"ERROR: input {o.Input} has the wrong format");
                        Console.ReadKey();
                        return;
                    }

                    // Initialize Rhino
                    try
                    {
                        using (new RhinoCore())
                        {
                            //var doc = Rhino.RhinoDoc.OpenHeadless(o.Input);
                            var file = Rhino.FileIO.File3dm.Read(o.Input);
                            if (file.Objects.Count != 1)
                            {
                                Console.WriteLine("Rhino files with multiple objects not supported yet");
                                Console.ReadKey();
                                return;
                            }
                            foreach (var item in file.Objects)
                            {
                                if (item.Geometry is PolyCurve curve)
                                {
                                    var gcode = CurveConverter.Convert(curve);
                                    if(gcode != null)
                                    {
                                        gcode.Save(o.Output);
                                        Console.WriteLine($"Wrote gcode to {o.Output}");
                                        Console.ReadKey();
                                        return;
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.ReadKey();
                    }


                });
        }
    }
}
