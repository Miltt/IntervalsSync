using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum IntervalsMenstrualPhase
    {
        [EnumMember(Value = "PERIOD")]
        Period, 
        [EnumMember(Value = "FOLLICULAR")]
        Follicular, 
        [EnumMember(Value = "OVULATING")]
        Ovulating, 
        [EnumMember(Value = "LUTEAL")]
        Luteal, 
        [EnumMember(Value = "NONE")]
        None 
    }
}