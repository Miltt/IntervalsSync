using Sync.Log;

namespace Sync
{
    public class ExternalClient
    {
        public class ExternalSourceData
        {
            public double? BodyFat { get; set; } 
            public double? Weight { get; set; }
            public double? Vo2Max { get; set; }
        }

        private readonly ExternalSourceData _source;
        private readonly ILogger _logger;

        public static async Task<ExternalClient> CreateAsync(IJsonReader jsonReader, ILogger logger, CancellationToken cancellationToken)
        {
            if (jsonReader is null)
                throw new ArgumentNullException(nameof(jsonReader));

            return new ExternalClient(
                source: await jsonReader.ReadFileAsync<ExternalSourceData>("../console/Clients/ExternalSource/externalsource.json", cancellationToken: cancellationToken),
                logger: logger);
        }

        private ExternalClient(ExternalSourceData? source, ILogger logger)
        {
            _source = source ?? throw new ArgumentNullException(nameof(source));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public double? GetBodyFat()
        {
            _logger.Add("Getting percentage data on body fat from an external source");

            return _source.BodyFat;
        }

        public double? GetWeight()
        {
            _logger.Add("Getting the body weight from an external source");

            return _source.Weight;
        }

        public double? GetVo2Max()
        {
            _logger.Add("Getting the Vo2Max data from an external source");

            return _source.Vo2Max;
        }
    }
}