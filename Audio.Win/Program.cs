using System.Windows.Forms;

namespace Audio.Win
{
    public class Program : AudioProgram
    {
        public Program(IEncoder encoder)
            : base(encoder)
        {
            Encoder = encoder;
        }

        public override void Start()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(Encoder));
        }
    }
}
