using Sync.Utilities.Logger;

namespace Sync
{
    public class ExternalDataCollector
    {
        public readonly struct Data
        {
            public double? BodyFat { get; }
            public double? Weight { get; }
            public double? Vo2Max { get; }

            public Data(double? bodyFat, double? weight, double? vo2max)
            {
                BodyFat = bodyFat;
                Weight = weight;
                Vo2Max = vo2max;
            }
        }

        private readonly ExternalClient _client;

        public static async Task<ExternalDataCollector> CreateAsync(IJsonReader jsonReader, ILogger logger, CancellationToken cancellationToken)
        {
            if (jsonReader is null)
                throw new ArgumentNullException(nameof(jsonReader));

            var client = await ExternalClient.CreateAsync(jsonReader, logger, cancellationToken);
            return new ExternalDataCollector(client);
        }

        private ExternalDataCollector(ExternalClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public Data GetData()
        {
            return new Data(
                bodyFat: _client.GetBodyFat(),
                weight: _client.GetWeight(),
                vo2max: _client.GetVo2Max());
        }
    }
}