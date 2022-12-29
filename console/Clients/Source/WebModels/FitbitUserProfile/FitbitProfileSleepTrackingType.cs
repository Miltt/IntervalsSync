using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FitbitProfileSleepTrackingType
    {
        [EnumMember(Value = "Normal")]
        Normal,
        [EnumMember(Value = "Sensitives")]
        Sensitive,
    }
}