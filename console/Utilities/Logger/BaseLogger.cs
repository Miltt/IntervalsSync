namespace Sync.Utilities.Logger
{
    public abstract class BaseLogger : ILogger
    {
        public static ILogger Create(string? filePath)
        {
            return !string.IsNullOrEmpty(filePath)
                ? new FileLogger(filePath)
                : new ConsoleLogger();
        }

        protected BaseLogger()
        {
        }

        public void Add(string message)
        {
            if (string.IsNullOrEmpty(message))
                return;

            AddInternal(message);
        }

        protected abstract void AddInternal(string message);
    }
}