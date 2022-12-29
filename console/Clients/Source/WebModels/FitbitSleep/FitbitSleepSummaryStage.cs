using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    public class FitbitSleepSummaryStage
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }
        [JsonPropertyName("minutes")]
        public int Minutes { get; set; }
        [JsonPropertyName("thirtyDayAvgMinutes")]
        public int ThirtyDayAvgMinutes { get; set; }

        public FitbitSleepSummaryStage()
        {
        }
    }
}