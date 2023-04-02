using Sync.Config;
using Sync.Log;
using Sync.Utilities;
using Sync.IntervalsUpdaters;

namespace Sync
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // TODO: args

            var logger = new Logger(Logger.OutputType.Console);
            var jsonFileManager = new JsonFileManager();
            var date = DateTime.Today; // TODO:
            
            try
            {
                logger.Add($"Sync started: {date.ToWebApiFormat()}");
                UpdateAsync(date, logger, jsonFileManager, CancellationToken.None).WaitAndUnwrapException();
            }
            catch (Exception e)
            {
                logger.Add(e.Message);
            }

            logger.Add("Sync completed");
        }

        private static async Task UpdateAsync(
            DateTime date,
            Logger logger,
            JsonFileManager jsonFileManager,
            CancellationToken cancellationToken)
        {
            if (logger is null)
                throw new ArgumentNullException(nameof(logger));
            if (jsonFileManager is null)
                throw new ArgumentNullException(nameof(jsonFileManager));

            var configManager = await AppConfigManager.CreateAsync(jsonFileManager, cancellationToken);

            var fitbitTokenManager = await FitbitTokenManager.CreateAsync(
                config: configManager.FitbitConfig,
                jsonFileManager: jsonFileManager,
                logger: logger,
                cancellationToken: cancellationToken);

            FitbitDataCollector.Wellness wellnessData;
            using (var fitbitCollector = new FitbitDataCollector(fitbitTokenManager, logger))
                wellnessData = await fitbitCollector.GetWellnessAsync(date, cancellationToken);

            var externalCollector = await ExternalDataCollector.CreateAsync(jsonFileManager, logger, cancellationToken);
            using (var intervalsCollector = new IntervalsUpdater(configManager.IntervalsConfig, logger))
                await intervalsCollector.UpdateWellnessAsync(date, wellnessData, externalCollector.GetData(), cancellationToken);
        }
    }
}