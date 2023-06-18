using System.Text;

namespace Sync.Log
{
    public sealed class FileLogger : BaseLogger
    {
        private const string FileName = "IntervalsSyncLog.txt";
        private readonly StringBuilder _stringBuilder;
        private readonly string _path;

        public FileLogger(string? filePath)
            : base()
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentException($"'{nameof(filePath)}' cannot be null or empty.", nameof(filePath));

            _stringBuilder = new StringBuilder();
            _path = $"{filePath}\\{FileName}";
        }

        protected override void AddInternal(string message)
        {
            _stringBuilder.Append(DateTime.Now.ToString()).Append(": ").AppendLine(message);
        }

        public async Task FlushAsync(CancellationToken cancellationToken)
        {
            using (var stream = File.Exists(_path)
                ? File.AppendText(_path)
                : new StreamWriter(_path))
            {
                await stream.WriteLineAsync(_stringBuilder, cancellationToken);
            }
        }
    }
}