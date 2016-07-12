using System;

namespace Audio.Console
{
    public class Program : IAudioProgram
    {
        private readonly IEncoder _encoder;
        private readonly string _originalName;
        private readonly string _newFileName;

        public Program(string originalFileName, string newFileName, IEncoder encoder)
        {
            _originalName = originalFileName;
            _newFileName = newFileName;
            _encoder = encoder;
        }

        public void Start()
        {
            try
            {
                _encoder.Encode(_originalName, _newFileName);
                System.Console.WriteLine("Done");
            }
            catch (UnauthorizedAccessException uaae)
            {
                System.Console.WriteLine(uaae.Message);
            }
        }
    }
}
