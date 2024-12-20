namespace Sync.Config
{
    internal sealed class AppConfigManager
    {
        private sealed class AppConfig
        {
            public FitbitConfig? FitbitConfig { get; set; }
            public IntervalsConfig? IntervalsConfig { get; set; }
            public DateTime LastUpdateDate { get; set; }
            public LoggerConfig? LoggerConfig { get; set; }
        }

        private const string FileName = "config.json";
        private readonly AppConfig _appConfig;

        public IFitbitConfig? FitbitConfig => _appConfig.FitbitConfig;
        public IIntervalsConfig? IntervalsConfig => _appConfig.IntervalsConfig;
        public DateTime LastUpdateDate => _appConfig.LastUpdateDate;
        public LoggerConfig? LoggerConfig => _appConfig.LoggerConfig;

        public static async Task<AppConfigManager> CreateAsync(IJsonReader jsonReader, CancellationToken cancellationToken)
        {
            if (jsonReader is null)
                throw new ArgumentNullException(nameof(jsonReader));

            return new AppConfigManager(
                appConfig: await jsonReader.ReadFileAsync<AppConfig>(FileName, cancellationToken));
        }

        private AppConfigManager(AppConfig? appConfig)
        {
            _appConfig = appConfig ?? throw new ArgumentNullException(nameof(appConfig));
        }

        public void SetLastUpdateDate(DateTime date)
        {
            _appConfig.LastUpdateDate = date;
        }

        public async Task SaveConfigAsync(IJsonWritter jsonWriter, CancellationToken cancellationToken)
        {
            if (jsonWriter is null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteFileAsync(_appConfig, FileName, cancellationToken);
        }
    }
}