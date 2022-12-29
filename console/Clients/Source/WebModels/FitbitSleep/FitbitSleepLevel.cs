using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    public class FitbitSleepLevel
    {
        [JsonPropertyName("data")]
        public List<FitbitSleepLevelData>? Data { get; set; }
        [JsonPropertyName("shortData")]
        public List<FitbitSleepLevelData>? ShortData { get; set; }
        [JsonPropertyName("summary")]
        public FitbitSleepLevelSummary? Summary { get; set; }

        public FitbitSleepLevel()
        {
        }
    }
}