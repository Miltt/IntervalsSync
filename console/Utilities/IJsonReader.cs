namespace Sync
{
    public interface IJsonReader
    {
        Task<T?> ReadFileAsync<T>(string path, CancellationToken cancellationToken)
            where T : class;
    }
}