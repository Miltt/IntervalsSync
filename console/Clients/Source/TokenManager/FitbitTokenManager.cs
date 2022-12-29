using System.Net.Http.Headers;
using System.Text.Json;
using Sync.Log;
using Sync.Utilities;
using Sync.WebModels;

namespace Sync
{
    public sealed class FitbitTokenManager : IFitbitTokenManager
    {
        private class Token
        {
            private const string FilePath = "../console/Clients/Source/token.json";
            private readonly IJsonFileManager _jsonFileManager;

            public FitbitOAuth2AccessToken? Value { get; private set; }

            public static async Task<Token> CreateAsync(IJsonFileManager jsonFileManager, CancellationToken cancellationToken)
            {
                var instance = new Token(jsonFileManager);
                await instance.ReadFileAsync(cancellationToken);
                return instance;
            }

            private Token(IJsonFileManager jsonFileManager)
            {
                _jsonFileManager = jsonFileManager ?? throw new ArgumentNullException(nameof(jsonFileManager));
            }

            private async Task ReadFileAsync(CancellationToken cancellationToken)
            {
                Value = await _jsonFileManager.ReadFileAsync<FitbitOAuth2AccessToken>(FilePath, cancellationToken);
            }

            public async Task WriteFileAsync(FitbitOAuth2AccessToken? value, CancellationToken cancellationToken)
            {
                Value = value ?? throw new ArgumentNullException(nameof(value));
                await _jsonFileManager.WriteFileAsync<FitbitOAuth2AccessToken>(value, FilePath, cancellationToken);
            }
        }

        private const string AuthorizationUrl = "https://www.fitbit.com/oauth2/authorize";
        private const string AccessRefresTokenUrl = "https://api.fitbit.com/oauth2/token";

        private readonly IFitbitConfig _config;
        private readonly ILogger _logger;
        private Token? _token;

        public static async Task<FitbitTokenManager> CreateAsync(IFitbitConfig? config, IJsonFileManager jsonFileManager, ILogger logger, CancellationToken cancellationToken)
        {
            var instance = new FitbitTokenManager(config, logger);
            await instance.InitializeAsync(jsonFileManager, cancellationToken);
            return instance;
        }

        private FitbitTokenManager(IFitbitConfig? config, ILogger logger)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<FitbitOAuth2AccessToken> GetTokenAsync(CancellationToken cancellationToken)
        {
            if (_token?.Value is null)
                throw new IntervalsSyncException("Token not found."); 
            if (_token.Value.IsFresh())
                return _token.Value;

            var token = await RefreshTokenAsync(cancellationToken);
            token?.SetExpirationDate();
            
            await _token.WriteFileAsync(token, cancellationToken);

            return _token.Value;
        }

        private async Task InitializeAsync(IJsonFileManager jsonFileManager, CancellationToken cancellationToken)
        {
            _token = await Token.CreateAsync(jsonFileManager, cancellationToken);

            if (_token.Value is null)
            {
                var token = await RequestTokenAsync(cancellationToken);
                token?.SetExpirationDate();

                await _token.WriteFileAsync(token, cancellationToken);
            }
        }

        private Task<FitbitOAuth2AccessToken?> RequestTokenAsync(CancellationToken cancellationToken)
        {
            _logger.Add("Obtain a new access token");

            // TODO: start oauth flow
            
            return Task.FromResult<FitbitOAuth2AccessToken?>(new FitbitOAuth2AccessToken());
        }

        private async Task<FitbitOAuth2AccessToken?> RefreshTokenAsync(CancellationToken cancellationToken)
        {
            _logger.Add("Refresh the access token");

            if (string.IsNullOrEmpty(_token?.Value?.RefreshToken))
                throw new IntervalsSyncException("Refresh token not found.");

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    scheme: "Basic", 
                    parameter: Helper.ConvertToBase64String($"{_config.ClientId}:{_config.ClientSecret}"));

                using (var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", "refresh_token"),
                    new KeyValuePair<string, string>("refresh_token", _token.Value.RefreshToken),
                }))
                using (var response = await httpClient.PostAsync(AccessRefresTokenUrl, content, cancellationToken))
                {
                    await response.VerifyResponseAsync();
                    var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);

                    return JsonSerializer.Deserialize<FitbitOAuth2AccessToken>(responseContent);
                }
            }
        }
    }
}