namespace Sync.Config
{
    public sealed class LoggerConfig
    {
        public string? FilePath { get; }

        public LoggerConfig(string? filePath)
        {
            FilePath = filePath;
        }
    }
}