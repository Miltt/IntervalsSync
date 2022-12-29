using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    public class FitbitFat
    {
        [JsonPropertyName("fat")]
        public List<FitbitFatLog>? FatLogs { get; set; }

        public FitbitFat()
        {
        }
    }
}