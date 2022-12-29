namespace Sync.Config
{
    public sealed class IntervalsConfig : IIntervalsConfig
    {
        public string UserId { get; set; }
        public string Username { get; }
        public string ApiKey { get; }

        public IntervalsConfig(string userId, string username, string apiKey)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException($"'{nameof(userId)}' cannot be null or empty.", nameof(userId));
            if (string.IsNullOrEmpty(username))
                throw new ArgumentException($"'{nameof(username)}' cannot be null or empty.", nameof(username));
            if (string.IsNullOrEmpty(apiKey))
                throw new ArgumentException($"'{nameof(apiKey)}' cannot be null or empty.", nameof(apiKey));

            UserId = userId;
            Username = username;
            ApiKey = apiKey;
        }
    }
}