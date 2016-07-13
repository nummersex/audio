using System;

namespace Audio.Console
{
    public class Program : AudioProgram
    {
        public Program(
            string originalFileName,
            string newFileName,
            IEncoder encoder)
            : base(
                originalFileName,
                newFileName,
                encoder)
        {
            OriginalFileName = originalFileName;
            NewFileName = newFileName;
            Encoder = encoder;
        }

        public override void Start()
        {
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
    }
}
