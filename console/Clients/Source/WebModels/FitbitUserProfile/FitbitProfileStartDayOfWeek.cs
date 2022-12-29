using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FitbitProfileStartDayOfWeek
    {
        [EnumMember(Value = "SUNDAY")]
        Sunday,
        [EnumMember(Value = "MONDAY")]
        Monday,
    }
}