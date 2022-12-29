using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    public class FitbitLogggedFoodUnit
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("plural")]
        public string? Plural { get; set; }

        public FitbitLogggedFoodUnit()
        {
        }
    }
}