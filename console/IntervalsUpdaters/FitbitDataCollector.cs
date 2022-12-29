using Sync.WebModels;
using Sync.Log;

namespace Sync.IntervalsUpdaters
{
    public class FitbitDataCollector : IDisposable
    {
        public readonly struct Wellness
        {
            public FitbitSpO2? SpO2 { get; }
            public FitbitHrv? Hrv { get; }
            public FitbitHrTimeSeries? HrTimeSeries { get; }
            public FitbitSleepLog? SleepLog { get; }
            public FitbitFoodLog? FoodLog { get; } 

            public Wellness(FitbitSpO2? spO2, FitbitHrv? hrv, FitbitHrTimeSeries? hrTimeSeries, FitbitSleepLog? sleepLog, FitbitFoodLog? foodLog)
            {
                SpO2 = spO2;
                Hrv = hrv;
                HrTimeSeries = hrTimeSeries;
                SleepLog = sleepLog;
                FoodLog = foodLog;
            }
        }

        private readonly FitbitClient _client;

        public FitbitDataCollector(FitbitTokenManager tokenManager, ILogger logger)
        {
            if (tokenManager is null)
                throw new ArgumentNullException(nameof(tokenManager));
            if (logger is null)
                throw new ArgumentNullException(nameof(logger));

            _client = new FitbitClient(tokenManager, logger);
        }

        public void Dispose()
        {
            _client.Dispose();
        }

        public async Task<Wellness> GetWellnessAsync(DateTime date, CancellationToken cancellationToken)
        {
            var spO2 = await _client.GetSpO2Async(
                userId: FitbitClient.CurrentUserId,
                date: date,
                cancellationToken: cancellationToken);
            var hrv = await _client.GetHrvAsync(
                userId: FitbitClient.CurrentUserId,
                date: date,
                cancellationToken: cancellationToken);
            var hrTimeSeries = await _client.GetHeartRateTimeSeriesAsync(
                userId: FitbitClient.CurrentUserId,
                date: date,
                period: FitbitRequestPeriod.OneDay,
                cancellationToken: cancellationToken);
            var sleepLog = await _client.GetSleepLogAsync(
                userId: FitbitClient.CurrentUserId,
                date: date,
                cancellationToken: cancellationToken);
            var foodLog = await _client.GetFoodLogAsync(
                userId: FitbitClient.CurrentUserId,
                date: date.AddDays(-1),
                cancellationToken: cancellationToken);
            
           return new Wellness(
                spO2: spO2,
                hrv: hrv,
                hrTimeSeries: hrTimeSeries,
                sleepLog: sleepLog,
                foodLog: foodLog);
        }
    }
}