using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    public class FitbitFoodLogSummary
    {
        [JsonPropertyName("calories")]
        public int Calories { get; set; }
        [JsonPropertyName("carbs")]
        public double Carbs { get; set; }
        [JsonPropertyName("fat")]
        public double Fat { get; set; }
        [JsonPropertyName("fiber")]
        public double Fiber { get; set; }
        [JsonPropertyName("protein")]
        public double Protein { get; set; }
        [JsonPropertyName("sodium")]
        public double Sodium { get; set; }
        [JsonPropertyName("water")]
        public int Water { get; set; }

        public FitbitFoodLogSummary()
        {
        }
    }
}