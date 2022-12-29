using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    public class FitbitProfileFeature
    {
        [JsonPropertyName("exerciseGoal")] 
        public bool ExerciseGoal { get; set; }

        public FitbitProfileFeature()
        {
        }
    }
}