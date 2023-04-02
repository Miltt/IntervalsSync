using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FitbitHrIntradayDetailLevel
    {
        [EnumMember(Value = "1sec")]
        OneSec,
        [EnumMember(Value = "1min")]
        OneMin,
        [EnumMember(Value = "5min")]
        FiveMin,
        [EnumMember(Value = "15min")]
        FifteenMin,
    }
}