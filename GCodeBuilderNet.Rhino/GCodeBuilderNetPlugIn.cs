﻿using Rhino;
using Rhino.FileIO;
using Rhino.PlugIns;
using System;

namespace GCodeBuilderNet.Rhino
{
    ///<summary>
    /// <para>Every RhinoCommon .rhp assembly must have one and only one PlugIn-derived
    /// class. DO NOT create instances of this class yourself. It is the
    /// responsibility of Rhino to create an instance of this class.</para>
    /// <para>To complete plug-in information, please also see all PlugInDescription
    /// attributes in AssemblyInfo.cs (you might need to click "Project" ->
    /// "Show All Files" to see it in the "Solution Explorer" window).</para>
    ///</summary>
    public class GCodeBuilderNetPlugIn : FileExportPlugIn
    {
        public GCodeBuilderNetPlugIn()
        {
            Instance = this;
        }

        ///<summary>Gets the only instance of the GCodeBuilderNetPlugIn plug-in.</summary>
        public static GCodeBuilderNetPlugIn Instance { get; private set; }

        /// <summary>Defines file extensions that this export plug-in is designed to write.</summary>
        /// <param name="options">Options that specify how to write files.</param>
        /// <returns>A list of file types that can be exported.</returns>
        protected override FileTypeList AddFileTypes(FileWriteOptions options)
        {
            var result = new FileTypeList();
            result.AddFileType("GCode data (*.gcode)", "gcode");
            return result;
        }

        /// <summary>
        /// Is called when a user requests to export a .gcode file.
        /// It is actually up to this method to write the file itself.
        /// </summary>
        /// <param name="filename">The complete path to the new file.</param>
        /// <param name="index">The index of the file type as it had been specified by the AddFileTypes method.</param>
        /// <param name="doc">The document to be written.</param>
        /// <param name="options">Options that specify how to write file.</param>
        /// <returns>A value that defines success or a specific failure.</returns>
        protected override WriteFileResult WriteFile(string filename, int index, RhinoDoc doc, FileWriteOptions options)
        {
            return WriteFileResult.Failure;
        }
        // You can override methods here to change the plug-in behavior on
        // loading and shut down, add options pages to the Rhino _Option command
        // and maintain plug-in wide options in a document.
    }
}