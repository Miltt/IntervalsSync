using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    public class FitbitHrIntradaySeriesHeartIntraday
    {
        [JsonPropertyName("dataset")]
        public List<FitbitHrIntradayDataset>? Dataset { get; set; }
        [JsonPropertyName("datasetInterval")]
        public int DatasetInterval { get; set; }
        [JsonPropertyName("datasetType")]
        public string? DatasetType { get; set; } // TODO: enum
    }
}