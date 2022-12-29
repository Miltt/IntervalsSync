using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    public class FitbitUserProfile
    {
        [JsonPropertyName("user")]
        public FitbitUser? User { get; set; }

        public FitbitUserProfile()
        {
        }
    }
}