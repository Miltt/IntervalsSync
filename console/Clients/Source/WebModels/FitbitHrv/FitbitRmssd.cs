using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    public class FitbitRmssd
    {
        [JsonPropertyName("dailyRmssd")]
        public double DailyRmssd { get; set; }
        [JsonPropertyName("deepRmssd")]
        public double DeepRmssd { get; set; }

        public FitbitRmssd()
        {
        }
    }
}