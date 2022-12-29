using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FitbitProfileDistanceUnit
    {
        [EnumMember(Value = "METRIC")]
        Metric,
    }
}