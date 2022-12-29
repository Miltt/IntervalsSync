using System.Text.Json.Serialization;

namespace Sync.WebModels
{   
    public class FitbitHrActivities
    {
        [JsonPropertyName("dateTime")]
        public DateTime? DateTime { get; set; }
        [JsonPropertyName("value")]
        public FitbitHrActivitiesValue? ActivitiesValue { get; set; }

        public FitbitHrActivities()
        {
        }
    }
}