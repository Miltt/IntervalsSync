using Sync.Log;

namespace Sync
{
    public abstract class BaseClient : IDisposable
    {
        protected readonly HttpClient _httpClient;
        protected readonly ILogger _logger;
        private bool _isDisposed;

        protected BaseClient(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _httpClient = new HttpClient();
        }

        public void Dispose()
        {
           Dispose(disposing: true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                    _httpClient.Dispose();

                _isDisposed = true;
            }
        }

        protected void ThrowIfUserIdIsInvalid(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException($"'{nameof(userId)}' cannot be null or empty.", nameof(userId));
        }

        protected void ThrowIfDateIsInvalid(DateTime date)
        {
            if (date == DateTime.MinValue || date > DateTime.Today)
                throw new ArgumentException($"'{nameof(date)}' date must not be greater than today", nameof(date));
        }
    }
}