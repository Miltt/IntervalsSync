using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    public class FitbitSleepStages
    {
        [JsonPropertyName("deep")]
        public int Deep { get; set; }
        [JsonPropertyName("light")]
        public int Light { get; set; }
        [JsonPropertyName("rem")]
        public int Rem { get; set; }
        [JsonPropertyName("wake")]
        public int Wake { get; set; }

        public FitbitSleepStages()
        {
        }
    }
}