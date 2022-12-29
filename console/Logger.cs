using System.Text;

namespace Sync.Log
{
    public class Logger : ILogger
    {
        public enum OutputType
        {
            Console = 0,
            File,
        }

        private readonly StringBuilder _stringBuilder;
        private readonly OutputType _type;

        public Logger(OutputType type)
        {
            _stringBuilder = new StringBuilder();
            _type = type;
        }

        public void Add(string message)
        {
            if (string.IsNullOrEmpty(message))
                return;

            switch (_type)
            {
                case OutputType.File:
                    _stringBuilder.AppendLine(message);
                    break;
                default:
                    Console.WriteLine(message);
                    break;
            }
        }

        public void Flush()
        {
            // TODO:
        }
    }
}