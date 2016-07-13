using System;
using System.IO;
using System.Reflection;

namespace Audio.Loader
{
    public class Program
    {
        private static IEncoder _encoder;
        private static AudioProgram _program;
        private const int Inputfile = 0;
        private const int Outputfile = 1;

        [STAThread]
        public static void Main(string[] args)
        {
            _encoder = new Encoder();

            switch (args.Length)
            {
                case 0:
                    _program = new Win.Program(_encoder);
                    break;
                case 1:
                    _program = new Console.Program(args[Inputfile], _encoder);
                    break;
                case 2:
                    _program = new Console.Program(args[Inputfile], args[Outputfile], _encoder);
                    break;
                default:
                    PrintUsage();
                    Environment.Exit(-1);
                    break;
            }

            _program.Start();
        }

        private static void PrintUsage()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            string name = Path.GetFileName(codeBase);

            System.Console.WriteLine("Usage: {0} file.wma [newfile.mp3]", name);
        }
    }
}
