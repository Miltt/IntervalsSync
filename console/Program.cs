using Sync.Config;
using Sync.Log;
using Sync.Utilities;
using Sync.IntervalsUpdaters;
using Sync.Enumerator;

namespace Sync
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // TODO: args

            var jsonFileManager = new JsonFileManager();

            UpdateAsync(jsonFileManager, CancellationToken.None).WaitAndUnwrapException();
        }

        private static async Task UpdateAsync(JsonFileManager jsonFileManager, CancellationToken cancellationToken)
        {
            if (jsonFileManager is null)
                throw new ArgumentNullException(nameof(jsonFileManager));

            var configManager = await AppConfigManager.CreateAsync(jsonFileManager, cancellationToken);
            var logger = BaseLogger.Create(configManager.LoggerConfig?.FilePath);
            var datePicker = new DatePicker(configManager.LastUpdateDate);

            foreach (var date in datePicker)
            {
                try
                {
                    logger.Add($"Sync started: {date.ToWebApiFormat()}");

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

                    configManager.SetLastUpdateDate(date);
                    await configManager.SaveConfigAsync(jsonFileManager, cancellationToken);

                    logger.Add("Sync completed");
                }
                catch (Exception e)
                {
                    logger.Add(e.Message);
                }
            }

            if (logger is FileLogger fileLogger)
                await fileLogger.FlushAsync(cancellationToken);
        }
    }
}