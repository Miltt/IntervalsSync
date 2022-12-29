using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    public class FitbitHrTimeSeries
    {
        [JsonPropertyName("activities-heart")]
        public List<FitbitHrActivities>? HrActivities { get; set; }

        public FitbitHrTimeSeries()
        {
        }
    }
}