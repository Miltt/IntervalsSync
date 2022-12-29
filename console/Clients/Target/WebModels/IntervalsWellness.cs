using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    public class IntervalsWellness
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }
        [JsonPropertyName("ctl")]
        public double? Ctl { get; set; }
        [JsonPropertyName("atl")]
        public double? Atl { get; set; }
        [JsonPropertyName("rampRate")]
        public double? RampRate { get; set; }
        [JsonPropertyName("ctlLoad")]
        public double? CtlLoad { get; set;}
        [JsonPropertyName("atlLoad")]
        public double? AtlLoad { get; set;}
        [JsonPropertyName("sportInfo")]
        public List<IntervalsSportInfo>? SportInfo { get; set; }
        [JsonPropertyName("updated")]
        public string? Updated { get; set;}
        [JsonPropertyName("weight")]
        public double? Weight { get; set; }
        [JsonPropertyName("restingHR")]
        public int? RestingHR { get; set; }
        [JsonPropertyName("hrv")]
        public double? Hrv { get; set; }
        [JsonPropertyName("hrvSDNN")]
        public double? HrvSDNN { get; set;}
        [JsonPropertyName("menstrualPhase")]
        public IntervalsMenstrualPhase? MenstrualPhase { get; set; }
        [JsonPropertyName("menstrualPhasePredicted")]
        public IntervalsMenstrualPhase? MenstrualPhasePredicted { get; set; }
        [JsonPropertyName("kcalConsumed")]
        public int? KcalConsumed { get; set; }
        [JsonPropertyName("sleepSecs")]
        public int? SleepSecs { get; set; }
        [JsonPropertyName("sleepScore")]
        public double? SleepScore { get; set; }
        [JsonPropertyName("sleepQuality")]
        public int? SleepQuality { get; set; }
        [JsonPropertyName("avgSleepingHR")]
        public double? AvgSleepingHR { get; set; }
        [JsonPropertyName("soreness")]
        public int? Soreness { get; set; }
        [JsonPropertyName("fatigue")]
        public int? Fatigue { get; set; }
        [JsonPropertyName("stress")]
        public int? Stress { get; set; }
        [JsonPropertyName("mood")]
        public int? Mood { get; set; }
        [JsonPropertyName("motivation")]
        public int? Motivation { get; set; }
        [JsonPropertyName("injury")]
        public int? Injury { get; set; }
        [JsonPropertyName("spO2")]
        public double? SpO2 { get; set; }
        [JsonPropertyName("systolic")]
        public int? Systolic { get; set; }
        [JsonPropertyName("diastolic")]
        public int? Diastolic { get; set; }
        [JsonPropertyName("hydration")]
        public int? Hydration { get; set; }
        [JsonPropertyName("hydrationVolume")]
        public double? HydrationVolume { get; set; }
        [JsonPropertyName("readiness")]
        public double? Readiness { get; set; }
        [JsonPropertyName("baevskySI")]
        public double? BaevskySI { get; set; }
        [JsonPropertyName("bloodGlucose")]
        public double? BloodGlucose { get; set; }
        [JsonPropertyName("lactate")]
        public double? Lactate { get; set; }
        [JsonPropertyName("bodyFat")]
        public double? BodyFat { get; set; }
        [JsonPropertyName("abdomen")]
        public double? Abdomen { get; set; }
        [JsonPropertyName("vo2max")]
        public double? Vo2max { get; set; }
        [JsonPropertyName("comments")]
        public string? Comments { get; set; }

        public IntervalsWellness()
        {
        }
    }
}