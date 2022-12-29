using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    public class FitbitHrv
    {
        [JsonPropertyName("hrv")]
        public List<FitbitHrvValue>? Values { get; set; }

        public FitbitHrv()
        {
        }
    }
}