using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    public class FitbitHrIntradaySeriesHeart
    {
        [JsonPropertyName("dateTime")]
        public DateTime DateTime { get; set; }
        [JsonPropertyName("value")]
        public string? Value { get; set; } // TODO: double
        [JsonPropertyName("customHeartRateZones")]
        public List<FitbitHrIntradayHeartRateZone>? CustomHeartRateZones { get; set; }
        [JsonPropertyName("heartRateZones")]
        public List<FitbitHrIntradayHeartRateZone>? HeartRateZones { get; set; }
    }
}