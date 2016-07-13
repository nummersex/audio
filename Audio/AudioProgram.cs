namespace Audio
{
    public abstract class AudioProgram
    {
        protected AudioProgram(string originalFileName,
            string newFileName,
            IEncoder encoder)
        {
            OriginalFileName = originalFileName;
            NewFileName = newFileName;
            Encoder = encoder;
        }

        public string OriginalFileName { get; set; }

        public string NewFileName { get; set; }    
    
        public IEncoder Encoder { get; set; }

        public virtual void Start()
        {
        }
    }
}