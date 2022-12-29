using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FitbitProfileTimeFormat
    {
        [EnumMember(Value = "12hour")]
        Format12,
        [EnumMember(Value = "24hour")]
        Format24
    }
}