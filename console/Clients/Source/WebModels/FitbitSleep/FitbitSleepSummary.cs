using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    public class FitbitSleepSummary
    {
        [JsonPropertyName("stages")]
        public FitbitSleepStages? Stages { get; set; }
        [JsonPropertyName("totalMinutesAsleep")]
        public int TotalMinutesAsleep { get; set; }
        [JsonPropertyName("totalSleepRecords")]
        public int TotalSleepRecords { get; set; }
        [JsonPropertyName("totalTimeInBed")]
        public int TotalTimeInBed { get; set; }

        public FitbitSleepSummary()
        {
        }
    }
}