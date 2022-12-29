namespace Sync.Config
{
    public sealed class FitbitConfig : IFitbitConfig
    {
        public string ClientId { get; }
        public string ClientSecret { get; }

        public FitbitConfig(string clientId, string clientSecret)
        {
            if (string.IsNullOrEmpty(clientId))
                throw new ArgumentException($"'{nameof(clientId)}' cannot be null or empty.", nameof(clientId));
            if (string.IsNullOrEmpty(clientSecret))
                throw new ArgumentException($"'{nameof(clientSecret)}' cannot be null or empty.", nameof(clientSecret));

            ClientId = clientId;
            ClientSecret = clientSecret;
        }
    }
}