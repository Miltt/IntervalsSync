using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FitbitLoggedFoodAccessLevel
    {
        [EnumMember(Value = "PUBLIC")]
        Public,
        [EnumMember(Value = "PRIVATE")]
        Private,
        [EnumMember(Value = "SHARED")]
        Shared,
    }
}