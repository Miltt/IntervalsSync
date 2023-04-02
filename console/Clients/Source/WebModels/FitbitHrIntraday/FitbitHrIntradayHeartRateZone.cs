using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    public class FitbitHrIntradayHeartRateZone
    {
        [JsonPropertyName("caloriesOut")]
        public double CaloriesOut { get; set; }
        [JsonPropertyName("max")]
        public int Max { get; set; }
        [JsonPropertyName("min")]
        public int Min { get; set; }
        [JsonPropertyName("minutes")]
        public int Minutes { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}