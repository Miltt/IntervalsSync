using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FitbitProfileWaterUnit
    {
        [EnumMember(Value = "METRIC")]
        Metric,
    }
}