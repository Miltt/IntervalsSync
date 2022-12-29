using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    public class FitbitSleepLevelSummary
    {
        [JsonPropertyName("deep")]
        public FitbitSleepSummaryStage? Deep { get; set; }
        [JsonPropertyName("light")]
        public FitbitSleepSummaryStage? Light { get; set; }
        [JsonPropertyName("rem")]
        public FitbitSleepSummaryStage? Rem { get; set; }
        [JsonPropertyName("wake")]
        public FitbitSleepSummaryStage? Wake { get; set; }

        public FitbitSleepLevelSummary()
        {
        }
    }
}