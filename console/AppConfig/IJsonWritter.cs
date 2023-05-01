namespace Sync
{
    public interface IJsonWritter
    {
        Task WriteFileAsync<T>(T value, string path, CancellationToken cancellationToken)
            where T : class;
    }
}