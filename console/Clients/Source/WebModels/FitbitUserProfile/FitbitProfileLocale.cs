using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FitbitProfileLocale
    {
        [EnumMember(Value = "en_US")]
        En_US = 0,
        [EnumMember(Value = "en_AU")]
        En_AU,
        [EnumMember(Value = "fr_FR")]
        Fr_FR,
        [EnumMember(Value = "de_DE")]
        De_DE,
        [EnumMember(Value = "ja_JP")]
        Ja_JP,
        [EnumMember(Value = "en_NZ")]
        En_NZ,
        [EnumMember(Value = "es_ES")]
        Es_ES,
        [EnumMember(Value = "en_GB")]
        En_GB,
    }
}