using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    public class FitbitFatLog
    {
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
        [JsonPropertyName("fat")]
        public double Fat { get; set; }
        [JsonPropertyName("logId")]
        public long LogId { get; set; }
        [JsonPropertyName("source")]
        public string? Source { get; set; }
        [JsonPropertyName("time")]
        public DateTime Time { get; set; }

        public FitbitFatLog()
        {
        }
    }
}