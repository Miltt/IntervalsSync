using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    public class FitbitFood
    {
        [JsonPropertyName("isFavorite")]
        public bool IsFavorite { get; set; }
        [JsonPropertyName("logDate")]
        public DateTime LogDate { get; set; }
        [JsonPropertyName("logId")]
        public long LogId { get; set; }
        [JsonPropertyName("loggedFood")]
        public FitbitLoggedFood? LoggedFood { get; set; }
        [JsonPropertyName("nutritionalValues")]
        public FitbitNutritionalValues? NutritionalValues { get; set; }

        public FitbitFood()
        {
        }
    }
}