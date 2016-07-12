namespace Audio
{
    public interface IEncoder
    {
        void Encode(string sourceFilename, string targetFilename);
    }
}