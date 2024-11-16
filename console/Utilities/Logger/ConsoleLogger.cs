namespace Sync.Utilities.Logger
{
    public sealed class ConsoleLogger : BaseLogger
    {
        public ConsoleLogger()
            : base()
        {
        }

        protected override void AddInternal(string message)
        {
            Console.WriteLine(message);
        }
    }
}