using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FitbitProfileHeightUnit
    {
        [EnumMember(Value = "METRIC")]
        Metric,
    }
}