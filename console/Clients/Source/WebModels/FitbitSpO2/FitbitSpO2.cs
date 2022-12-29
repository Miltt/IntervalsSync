using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    public class FitbitSpO2
    {
        [JsonPropertyName("dateTime")]
        public DateTime DateTime { get; set; }
        [JsonPropertyName("value")]
        public FitbitSpO2Value? Value { get; set; }

        public FitbitSpO2()
        {
        }
    }
}