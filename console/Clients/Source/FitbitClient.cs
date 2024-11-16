using System.Net.Http.Headers;
using System.Text.Json;
using Sync.Utilities.Logger;
using Sync.Utilities;
using Sync.WebModels;

namespace Sync
{
    public sealed class FitbitClient : BaseClient
    {
        public const string BaseUrl = "https://api.fitbit.com/";
        public const string CurrentUserId = "-";

        private readonly IFitbitTokenManager _fitbitTokenManager;

        public FitbitClient(IFitbitTokenManager fitbitTokenManager, ILogger logger)
            : base(logger)
        {
            _fitbitTokenManager = fitbitTokenManager ?? throw new ArgumentNullException(nameof(fitbitTokenManager));
        }

        public async Task<FitbitUserProfile?> GetProfileAsync(string userId, CancellationToken cancellationToken)
        {
            ThrowIfUserIdIsInvalid(userId);

            _logger.Add($"Getting the user's profile data: {userId}");

            return await GetAsync<FitbitUserProfile>(
                url: $"{BaseUrl}1/user/{userId}/profile.json",
                cancellationToken: cancellationToken);
        }

        public async Task<FitbitFoodLog?> GetFoodLogAsync(string userId, DateTime date, CancellationToken cancellationToken)
        {
            ThrowIfUserIdIsInvalid(userId);
            ThrowIfDateIsInvalid(date);

            _logger.Add($"Getting a summary of the user's food log entry for a given day: {userId}");

            return await GetAsync<FitbitFoodLog>(
                url: $"{BaseUrl}1/user/{userId}/foods/log/date/{date.ToWebApiFormat()}.json",
                cancellationToken: cancellationToken);
        }

        public async Task<FitbitWeight?> GetWeightLogAsync(string userId, DateTime date, CancellationToken cancellationToken)
        {
            ThrowIfUserIdIsInvalid(userId);
            ThrowIfDateIsInvalid(date);

            _logger.Add($"Getting a list of all user's weight log entries for a given date {userId}");

            return await GetAsync<FitbitWeight>(
                url: $"{BaseUrl}1/user/{userId}/body/log/weight/date/{date.ToWebApiFormat()}.json",
                cancellationToken: cancellationToken);
        }

        public async Task<FitbitFat?> GetFatLogAsync(string userId, DateTime date, CancellationToken cancellationToken)
        {
            ThrowIfUserIdIsInvalid(userId);
            ThrowIfDateIsInvalid(date);

            _logger.Add($"Getting a list of all user's body fat log entries for a given date {userId}");

            return await GetAsync<FitbitFat>(
                url: $"{BaseUrl}1/user/{userId}/body/log/fat/date/{date.ToWebApiFormat()}.json",
                cancellationToken: cancellationToken);
        }

        public async Task<FitbitSpO2?> GetSpO2Async(string userId, DateTime date, CancellationToken cancellationToken)
        {
            ThrowIfUserIdIsInvalid(userId);
            ThrowIfDateIsInvalid(date);

            _logger.Add($"Getting the SpO2 summary data for a single date {userId}");

            return await GetAsync<FitbitSpO2>(
                url: $"{BaseUrl}1/user/{userId}/spo2/date/{date.ToWebApiFormat()}.json",
                cancellationToken: cancellationToken);
        }

        public async Task<FitbitHrv?> GetHrvAsync(string userId, DateTime date, CancellationToken cancellationToken)
        {
            ThrowIfUserIdIsInvalid(userId);
            ThrowIfDateIsInvalid(date);

            _logger.Add($"Getting the Heart Rate Variability (HRV) data for a single date {userId}");

            return await GetAsync<FitbitHrv>(
                url: $"{BaseUrl}1/user/{userId}/hrv/date/{date.ToWebApiFormat()}.json",
                cancellationToken: cancellationToken);
        }

        public async Task<FitbitHrTimeSeries?> GetHeartRateTimeSeriesAsync(string userId, DateTime date, FitbitRequestPeriod period, 
            CancellationToken cancellationToken)
        {
            ThrowIfUserIdIsInvalid(userId);
            ThrowIfDateIsInvalid(date);

            _logger.Add($"Getting the heart rate time series data over a period of time by specifying a date and time period {userId}");

            return await GetAsync<FitbitHrTimeSeries>(
                url: $"{BaseUrl}1/user/{userId}/activities/heart/date/{date.ToWebApiFormat()}/{period.GetDescription()}.json",
                cancellationToken: cancellationToken);
        }

        public async Task<FitbitHrIntradaySeries?> GetHeartRateIntradayAsync(string userId, DateTime startDate, DateTime endDate, 
            string level, 
            CancellationToken cancellationToken)
        {
            ThrowIfUserIdIsInvalid(userId);
            ThrowIfDateIsInvalid(startDate);
            ThrowIfDateIsInvalid(endDate);

            _logger.Add($"Getting the heart rate intraday time series data on a specific date range for a 24 hour period {userId}");

            return await GetAsync<FitbitHrIntradaySeries>(
                url: $"{BaseUrl}1/user/{userId}/activities/heart/date/{startDate.ToWebApiFormat()}/{endDate.ToWebApiFormat()}/{level}/time/{startDate.ToWebApiTimeFormat()}/{endDate.ToWebApiTimeFormat()}.json",
                cancellationToken: cancellationToken);
        }

        public async Task<FitbitSleepLog?> GetSleepLogAsync(string userId, DateTime date, CancellationToken cancellationToken)
        {
            ThrowIfUserIdIsInvalid(userId);
            ThrowIfDateIsInvalid(date);

            _logger.Add($"Getting a list of a user's sleep log entries for a given date {userId}");

            return await GetAsync<FitbitSleepLog>(
                url: $"{BaseUrl}1.2/user/{userId}/sleep/date/{date.ToWebApiFormat()}.json",
                cancellationToken: cancellationToken);
        }

        private async Task<T?> GetAsync<T>(string url, CancellationToken cancellationToken)
            where T: class
        {
            using (var request = new HttpRequestMessage(
                method: HttpMethod.Get,
                requestUri: url))
            {
                var token = await _fitbitTokenManager.GetTokenAsync(cancellationToken);

                request.Headers.Authorization = new AuthenticationHeaderValue(
                    scheme: "Bearer",
                    parameter: token.Token);

                using (var response = await _httpClient.SendAsync(request, cancellationToken))
                {
                    await response.VerifyResponseAsync();
                    var responseContent = await response.Content.ReadAsStringAsync();

                    return JsonSerializer.Deserialize<T>(responseContent);
                }
            }
        }
    }
} 