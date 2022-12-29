using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FitbitSleepType
    {
        [EnumMember(Value = "classic")]
        Classic,
        [EnumMember(Value = "stages")]
        Stages
    }
}