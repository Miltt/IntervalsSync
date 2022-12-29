using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    public class FitbitSleepLog
    {
        [JsonPropertyName("sleep")]
        public List<FitbitSleep>? Sleep { get; set; }
        [JsonPropertyName("summary")]
        public FitbitSleepSummary? Summary { get; set; }

        public FitbitSleepLog()
        {
        }
    }
}