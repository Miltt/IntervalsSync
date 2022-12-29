using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Sync.Log;
using Sync.Utilities;
using Sync.WebModels;

namespace Sync
{
    public sealed class IntervalsClient : BaseClient
    {
        public const string BaseUrl = "https://intervals.icu/";

        public IntervalsClient(IIntervalsConfig? config, ILogger logger)
            : base (logger)
        {
            if (config is null)
                throw new ArgumentNullException(nameof(config));

            _httpClient.BaseAddress = new Uri(BaseUrl);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(
                mediaType: "application/json"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                scheme: "Basic",
                parameter: Helper.ConvertToBase64String($"{config.Username}:{config.ApiKey}"));
        }

        public async Task<IntervalsWellness?> GetWelnessAsync(string userId, DateTime date, CancellationToken cancellationToken)
        {
            ThrowIfUserIdIsInvalid(userId);
            ThrowIfDateIsInvalid(date);

            _logger.Add($"Getting the user's wellness data: {userId}");

            using (var response = await _httpClient.GetAsync(
                requestUri: $"{BaseUrl}api/v1/athlete/{userId}/wellness/{date.ToWebApiFormat()}",
                cancellationToken: cancellationToken))
            {
                await response.VerifyResponseAsync();
                var responseContent = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<IntervalsWellness>(responseContent);
            }
        }

        public async Task<IntervalsWellness?> PutWelnessAsync(IntervalsWellness? wellness, string userId, DateTime date, CancellationToken cancellationToken)
        {
            if (wellness is null)
                throw new ArgumentNullException(nameof(wellness));

            ThrowIfUserIdIsInvalid(userId);
            ThrowIfDateIsInvalid(date);

            _logger.Add($"Updating the user's wellness data: {userId}");

            using (var content = new StringContent(
                content: JsonSerializer.Serialize(wellness),
                encoding: Encoding.UTF8,
                mediaType: new MediaTypeHeaderValue("application/json")))
            using (var response = await _httpClient.PutAsync(
                requestUri: $"{BaseUrl}api/v1/athlete/{userId}/wellness/{date.ToWebApiFormat()}",
                content: content, 
                cancellationToken: cancellationToken))
            {
                await response.VerifyResponseAsync();
                var responseContent = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<IntervalsWellness>(responseContent);
            }
        }
    }
}