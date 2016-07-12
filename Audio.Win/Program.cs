using System.Windows.Forms;

namespace Audio.Win
{
    public class Program : IAudioProgram
    {
        private readonly string _originalFileName;
        private readonly string _newFileName;
        private readonly IEncoder _encoder;

        public Program(
            string originalFileName,
            string newFileName,
            IEncoder encoder)
        {
            _originalFileName = originalFileName;
            _newFileName = newFileName;
            _encoder = encoder;
        }

        public void Start()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(_encoder));
        }
    }
}
