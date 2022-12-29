using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    public class FitbitFoodLog
    {
        [JsonPropertyName("foods")]
        public List<FitbitFood>? Foods { get; set; }
        [JsonPropertyName("goals")]
        public FitbitFoodLogGoals? Goals { get; set; }
        [JsonPropertyName("summary")]
        public FitbitFoodLogSummary? Summary { get; set; }

        public FitbitFoodLog()
        {
        }
    }
}