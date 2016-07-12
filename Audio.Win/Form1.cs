using System;
using System.Windows.Forms;

namespace Audio.Win
{
    public sealed partial class Form1 : Form
    {
        private readonly IEncoder _encoder;
        public Form1(IEncoder encoder)
        {
            InitializeComponent();
            _encoder = encoder;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            var textBefore = "Drag file here to encode";
            label1.Text = "Converting file(s)";

            foreach (string originalFileName in files)
            {
                label1.Text = "Converting " + originalFileName.Substring(originalFileName.LastIndexOf("\\", StringComparison.Ordinal)+1);
                var newFileName = originalFileName.Substring(0, originalFileName.LastIndexOf(".", StringComparison.Ordinal)) + ".mp3";

                try
                {
                    _encoder.Encode(originalFileName, newFileName);
                    label1.Text = textBefore;
                }
                catch (UnauthorizedAccessException uaae)
                {
                    label1.Text = uaae.Message;
                }
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            label1.Text = "Drag file here to encode";
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }
    }
}
