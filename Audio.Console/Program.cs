using System;
using System.IO;

namespace Audio.Console
{
    public class Program : AudioProgram
    {
        /// <summary>
        /// Constructor for usage when only original filename is supplied
        /// </summary>
        /// <param name="originalFileName">Input file</param>
        /// <param name="encoder">Encoder</param>
        public Program(
            string originalFileName,
            IEncoder encoder)
            : base(
                originalFileName,
                string.Empty,
                encoder)
        {
        }

        /// <summary>
        /// Constructor when both original and new filename is supplied
        /// </summary>
        /// <param name="originalFileName">Input file</param>
        /// <param name="newFileName">Output file</param>
        /// <param name="encoder">Encoder</param>
        public Program(
            string originalFileName,
            string newFileName,
            IEncoder encoder)
            : base(
                originalFileName,
                newFileName,
                encoder)
        {
        }

        public override void Start()
        {
            if (!File.Exists(OriginalFileName))
                PrintErrorMessageAndExit(string.Format("Source file {0} doesn't exist", OriginalFileName));

            NewFileName = !string.IsNullOrEmpty(NewFileName) ?
                NewFileName :
                OriginalFileName.Substring(0, OriginalFileName.LastIndexOf(".", StringComparison.Ordinal)) + ".mp3";

            if (!NewFileName.EndsWith(".mp3"))
                PrintErrorMessageAndExit("Output file must the .mp3 extension");

            try
            {
                Encoder.Encode(OriginalFileName, NewFileName);
                System.Console.WriteLine("Done");
            }
            catch (UnauthorizedAccessException uaae)
            {
                System.Console.WriteLine(uaae.Message);
                Environment.Exit(-1);
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                System.Console.WriteLine("The input file has an unsupported file format");
                Environment.Exit(-1);
            }
        }

        private static void PrintErrorMessageAndExit(string message)
        {
            System.Console.WriteLine(message);
            Environment.Exit(-1);
        }
    }
}
