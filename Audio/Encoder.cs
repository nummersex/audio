namespace Audio
{
    public class Encoder : IEncoder
    {
        public void Encode(string sourceFilename, string targetFilename)
        {
            using (var reader = new NAudio.Wave.AudioFileReader(sourceFilename))
            using (
                var writer = new NAudio.Lame.LameMP3FileWriter(targetFilename, reader.WaveFormat,
                    NAudio.Lame.LAMEPreset.STANDARD))
            {
                reader.CopyTo(writer);
            }
        }
    }
}