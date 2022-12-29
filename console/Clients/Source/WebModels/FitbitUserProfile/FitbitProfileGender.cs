using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FitbitProfileGender
    {
        [EnumMember(Value = "NA")]
        NA = 0,
        [EnumMember(Value = "MALE")]
        Male,
        [EnumMember(Value = "FEMALE")]
        Female,
    }
}