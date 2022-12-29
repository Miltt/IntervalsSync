using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FitbitProfileStrideLengthType
    {
        [EnumMember(Value = "auto")]
        Auto,
        [EnumMember(Value = "manual")]
        Manual,
    }
}