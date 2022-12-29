using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    public class FitbitLoggedFood
    {
        [JsonPropertyName("accessLevel")]
        public FitbitLoggedFoodAccessLevel AccessLevel { get; set; }
        [JsonPropertyName("amount")]
        public int Amount { get; set; }
        [JsonPropertyName("brand")]
        public string? Brand { get; set; }
        [JsonPropertyName("calories")]
        public int Calories { get; set; }
        [JsonPropertyName("foodId")]
        public int FoodId { get; set; }
        [JsonPropertyName("mealTypeId")]
        public int MealTypeId { get; set; } // TODO: enum
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("unit")]
        public FitbitLogggedFoodUnit? Unit { get; set; }
        [JsonPropertyName("units")]
        public List<int>? Units { get; set; }

        public FitbitLoggedFood()
        {
        }
    }
}