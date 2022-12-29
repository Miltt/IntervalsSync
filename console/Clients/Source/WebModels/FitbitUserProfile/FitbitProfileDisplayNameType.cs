using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FitbitProfileDisplayNameType
    {
        [EnumMember(Value = "name")]
        Name,
        [EnumMember(Value = "username")]
        Username
    }
}