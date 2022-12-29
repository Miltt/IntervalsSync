using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FitbitSleepLogType
    {
        [EnumMember(Value = "auto_detected")]
        Auto = 0,
        [EnumMember(Value = "manual")]
        Manual
    }
}