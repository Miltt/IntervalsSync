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
            public FitbitHrIntradaySeries? HrIntradaySeries { get; }
            public FitbitSleepLog? SleepLog { get; }
            public FitbitFoodLog? FoodLog { get; } 

            public Wellness(FitbitSpO2? spO2, FitbitHrv? hrv, FitbitHrTimeSeries? hrTimeSeries, FitbitHrIntradaySeries? hrIntradaySeries, 
                FitbitSleepLog? sleepLog, 
                FitbitFoodLog? foodLog)
            {
                SpO2 = spO2;
                Hrv = hrv;
                HrTimeSeries = hrTimeSeries;
                HrIntradaySeries = hrIntradaySeries;
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
            
            var hrIntradaySeries = null as FitbitHrIntradaySeries;

            var fitbitSleep = sleepLog?.Sleep?.FirstOrDefault();
            if (fitbitSleep != null)
            {
                hrIntradaySeries = await _client.GetHeartRateIntradayAsync(
                    userId: FitbitClient.CurrentUserId,
                    startDate: fitbitSleep.StartTime,
                    endDate: fitbitSleep.EndTime,
                    level: FitbitHrIntradayDetailLevel.OneMin.ToDto(),
                    cancellationToken: cancellationToken);
            }

            var foodLog = await _client.GetFoodLogAsync(
                userId: FitbitClient.CurrentUserId,
                date: date.AddDays(-1),
                cancellationToken: cancellationToken);
            
           return new Wellness(
                spO2: spO2,
                hrv: hrv,
                hrTimeSeries: hrTimeSeries,
                hrIntradaySeries: hrIntradaySeries,
                sleepLog: sleepLog,
                foodLog: foodLog);
        }
    }
}