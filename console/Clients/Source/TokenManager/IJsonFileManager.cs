namespace Sync
{
    public interface IJsonFileManager
    {
        Task<T?> ReadFileAsync<T>(string path, CancellationToken cancellationToken)
            where T : class;
        Task WriteFileAsync<T>(T value, string path, CancellationToken cancellationToken)
            where T : class;
    }
}