using System.Text;
using System.Text.Json;

namespace Sync.Utilities
{
    public class JsonFileManager : IJsonFileManager, IJsonReader, IJsonWritter
    {
        public async Task<T?> ReadFileAsync<T>(string path, CancellationToken cancellationToken)
            where T : class 
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentException($"'{nameof(path)}' cannot be null or empty.", nameof(path));
            if (!File.Exists(path))
                throw new ArgumentException($"Specified file not found {path}.");

            var json = await File.ReadAllTextAsync(path, Encoding.UTF8, cancellationToken);
            
            return !string.IsNullOrEmpty(json)
                ? JsonSerializer.Deserialize<T>(json)
                : null;
        }

        public async Task WriteFileAsync<T>(T value, string path, CancellationToken cancellationToken)
            where T : class 
        {
            ArgumentNullException.ThrowIfNull(value);
            if (string.IsNullOrEmpty(path))
                throw new ArgumentException($"'{nameof(path)}' cannot be null or empty.", nameof(path));
            if (!File.Exists(path))
                throw new ArgumentException($"Specified file not found {path}.");

            var valueStr = JsonSerializer.Serialize(value);
            if (!string.IsNullOrEmpty(valueStr))
                await File.WriteAllTextAsync(path, valueStr, cancellationToken);
        }
    }
}