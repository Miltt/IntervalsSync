using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    public class FitbitSleepLevelData
    {
        [JsonPropertyName("dateTime")]
        public DateTime DateTime { get; set; }
        [JsonPropertyName("level")]
        public string? Level { get; set; }
        [JsonPropertyName("seconds")]
        public long Seconds { get; set; }

        public FitbitSleepLevelData()
        {
        }
    }
}