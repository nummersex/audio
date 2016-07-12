using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace Audio.Loader
{
    public class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int SW_HIDE = 0;
        private static IEncoder _encoder;
        private static Win.Program _winProgram;
        private static Console.Program _consoleProgram;

        [STAThread]
        public static void Main(string[] args)
        {
            _encoder = new Encoder();

            switch (args.Length)
            {
                case 0:
                    StartWindow();
                    break;
                case 2:
                    StartConsole(args, _encoder);
                    break;
            }
        }

        private static void StartWindow()
        {
            // Hide
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);
            _winProgram = new Win.Program(string.Empty, string.Empty, _encoder);
            _winProgram.Start();
        }

        private static void StartConsole(IReadOnlyList<string> args, IEncoder encoder)
        {
            var originalFileName = args[0];

            if (!File.Exists(originalFileName))
                PrintErrorMessageAndExit("Source file doesn't exist");

            var newFileName = args[1];
            if (!newFileName.EndsWith(".mp3"))
                PrintErrorMessageAndExit("New filename must end with .mp3");

            _consoleProgram = new Console.Program(originalFileName, newFileName, _encoder);
            _consoleProgram.Start();
            
            System.Console.WriteLine("Done");
        }

        private static void PrintErrorMessageAndExit(string message)
        {
            System.Console.WriteLine(message);
            Environment.Exit(-1);
        }
    }
}
