using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    public class FitbitSpO2Value
    {
        [JsonPropertyName("avg")]
        public double Avg { get; set; }
        [JsonPropertyName("min")]
        public double Min{ get; set; }
        [JsonPropertyName ("max")]
        public double Max { get; set; }

        public FitbitSpO2Value()
        {
        }
    }
}