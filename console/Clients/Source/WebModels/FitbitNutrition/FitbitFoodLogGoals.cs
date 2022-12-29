using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    public class FitbitFoodLogGoals
    {
        [JsonPropertyName("calories")]
        public int Calories { get; set; }

        public FitbitFoodLogGoals()
        {
        }
    }
}