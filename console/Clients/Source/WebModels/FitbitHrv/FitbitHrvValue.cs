using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    public class FitbitHrvValue
    {
        [JsonPropertyName("value")]
        public FitbitRmssd? Rmssd { get; set; }
        [JsonPropertyName("dateTime")]
        public string? DateTime { get; set; }

        public FitbitHrvValue()
        {
        }
    }
}