using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    public class FitbitHrActivitiesValue
    {
        [JsonPropertyName("customHeartRateZones")]
        public List<HeartRateZone>? CustomHeartRateZones { get; set; }
        [JsonPropertyName("heartRateZones")]
        public List<HeartRateZone>? HeartRateZones { get; set; }
        [JsonPropertyName("restingHeartRate")]
        public int RestingHeartRate { get; set; }

        public FitbitHrActivitiesValue()
        {
        }
    }
}