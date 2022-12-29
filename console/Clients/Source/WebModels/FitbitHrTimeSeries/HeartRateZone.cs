using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    public class HeartRateZone
    {
        [JsonPropertyName("caloriesOut")]
        public double BurnedCalories { get; set; }
        [JsonPropertyName("max")]
        public int Max { get; set; }
        [JsonPropertyName("min")]
        public int Min { get; set; }
        [JsonPropertyName("minutes")]
        public int Minutes { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        public HeartRateZone()
        {
        }
    }
}