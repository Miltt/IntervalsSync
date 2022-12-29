using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FitbitProfileBadgeType
    {
        [EnumMember(Value = "DAILY_STEPS")]
        DailySteps,
        [EnumMember(Value = "LIFETIME_DISTANCE")]
        LifetimeDistance,
        [EnumMember(Value = "DAILY_FLOORS")]
        DailyFloors,
        [EnumMember(Value = "LIFETIME_FLOORS")]
        LifetimeFloors,
    }
}