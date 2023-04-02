using Sync.Log;

namespace Sync.IntervalsUpdaters
{
    public class IntervalsUpdater : IDisposable
    {
        private readonly IntervalsClient _client;
        private readonly IIntervalsConfig _config;
        private readonly IntervalsModelBuilder _modelBuilder;

        public IntervalsUpdater(IIntervalsConfig? config, ILogger logger)
        {
            if (logger is null)
                throw new ArgumentNullException(nameof(logger));

            _client = new IntervalsClient(config, logger);
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _modelBuilder = new IntervalsModelBuilder();
        }

        public void Dispose()
        {
            _client.Dispose();
        }

        public async Task UpdateWellnessAsync(DateTime date, FitbitDataCollector.Wellness wellnessData, 
            ExternalDataCollector.Data data, 
            CancellationToken cancellationToken)
        {
            await UpdateWellnessInternalAsync(
                date: date,
                wellnessData: wellnessData,
                data: data,
                cancellationToken: cancellationToken);

            await UpdateCaloriesInternalAsync(
                date: date.AddDays(-1), // previous day
                wellnessData: wellnessData,
                cancellationToken: cancellationToken);
        }

        private async Task UpdateWellnessInternalAsync(DateTime date, FitbitDataCollector.Wellness wellnessData, 
            ExternalDataCollector.Data data, 
            CancellationToken cancellationToken)
        {
            var intervalWellness = await _client.GetWelnessAsync(
                userId: _config.UserId,
                date: date,
                cancellationToken: cancellationToken);

            _modelBuilder.BuildWellness(intervalWellness, wellnessData, data);

            await _client.PutWelnessAsync(
                wellness: intervalWellness,
                userId: _config.UserId,
                date: date,
                cancellationToken: cancellationToken);
        }

        private async Task UpdateCaloriesInternalAsync(DateTime date, FitbitDataCollector.Wellness wellnessData, CancellationToken cancellationToken)
        {
            var intervalWellness = await _client.GetWelnessAsync(
                userId: _config.UserId,
                date: date,
                cancellationToken: cancellationToken);

            _modelBuilder.BuildCalories(intervalWellness, wellnessData);

            await _client.PutWelnessAsync(
                wellness: intervalWellness,
                userId: _config.UserId,
                date: date,
                cancellationToken: cancellationToken);
        }
    }
}