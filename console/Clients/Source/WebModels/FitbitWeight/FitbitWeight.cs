using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    public class FitbitWeight
    {
        [JsonPropertyName("weight")]
        public List<FitbitWeightLog>? WeightLogs { get; set; }

        public FitbitWeight()
        {
        }
    }
}