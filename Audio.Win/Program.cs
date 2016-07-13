using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Audio.Win
{
    public class Program : AudioProgram
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int SW_HIDE = 0;

        public Program(IEncoder encoder)
            : base(encoder)
        {
            Encoder = encoder;
        }

        public override void Start()
        {
            // Hide
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(Encoder));
        }
    }
}
