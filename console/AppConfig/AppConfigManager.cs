namespace Sync.Config
{
    internal sealed class AppConfigManager
    {
        private sealed class AppConfig
        {
            public FitbitConfig? FitbitConfig { get; set; }
            public IntervalsConfig? IntervalsConfig { get; set; }
        }

        private readonly AppConfig _appConfig;

        public IFitbitConfig? FitbitConfig => _appConfig.FitbitConfig;
        public IIntervalsConfig? IntervalsConfig => _appConfig.IntervalsConfig;

        public static async Task<AppConfigManager> CreateAsync(IJsonReader jsonReader, CancellationToken cancellationToken)
        {
            if (jsonReader is null)
                throw new ArgumentNullException(nameof(jsonReader));

            return new AppConfigManager(
                appConfig: await jsonReader.ReadFileAsync<AppConfig>("../console/AppConfig/config.json", cancellationToken));
        }

        private AppConfigManager(AppConfig? appConfig)
        {
            _appConfig = appConfig ?? throw new ArgumentNullException(nameof(appConfig));
        }
    }
}