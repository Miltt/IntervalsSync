using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    public class FitbitHrIntradayDataset
    {
        [JsonPropertyName("time")]
        public string? Time { get; set; }
        [JsonPropertyName("value")]
        public int Value { get; set; }
    }
}