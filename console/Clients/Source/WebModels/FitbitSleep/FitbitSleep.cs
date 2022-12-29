using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    public class FitbitSleep
    {
        [JsonPropertyName("dateOfSleep")]
        public DateTime DateOfSleep { get; set; }
        /// <summary>
        /// Length of the sleep in milliseconds
        /// </summary>
        [JsonPropertyName("duration")]
        public long Duration { get; set; }
        [JsonPropertyName("efficiency")]
        public int Efficiency { get; set; }
        [JsonPropertyName("endTime")]
        public DateTime EndTime { get; set; }
        [JsonPropertyName("infoCode")]
        public int InfoCode { get; set; }
        [JsonPropertyName("isMainSleep")]
        public bool IsMainSleep { get; set; }
        [JsonPropertyName("logId")]
        public long LogId { get; set; }
        [JsonPropertyName("minutesAfterWakeup")]
        public int MinutesAfterWakeup { get; set; }
        [JsonPropertyName("minutesAsleep")]
        public int MinutesAsleep { get; set; }
        [JsonPropertyName("minutesAwake")]
        public int MinutesAwake { get; set; }
        [JsonPropertyName("minutesToFallAsleep")]
        public int MinutesToFallAsleep { get; set; }
        [JsonPropertyName("logType")]
        public string? LogType { get; set; } // TODO: enum FitbitSleepLogType
        [JsonPropertyName("startTime")]
        public DateTime StartTime { get; set; }
        [JsonPropertyName("timeInBed")]
        public int TimeInBed { get; set; }
        [JsonPropertyName("type")]
        public FitbitSleepType Type { get; set; }
        [JsonPropertyName("levels")]
        public FitbitSleepLevel? Levels { get; set; }

        public FitbitSleep()
        {
        }
    }
}