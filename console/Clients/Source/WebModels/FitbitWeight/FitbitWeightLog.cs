using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    public class FitbitWeightLog
    {
        [JsonPropertyName("bmi")]
        public double Bmi { get; set; }
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
        [JsonPropertyName("weight")]
        public long Weight { get; set; }

        public FitbitWeightLog()
        {
        }
    }
}