using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum IntervalsType
    {
        [EnumMember(Value = "Ride")]
        Ride,
        [EnumMember(Value = "Run")]
        Run, 
        [EnumMember(Value = "Swim")]
        Swim, 
        [EnumMember(Value = "WeightTraining")]
        WeightTraining,
        [EnumMember(Value = "Hike")]
        Hike, 
        [EnumMember(Value = "Walk")]
        Walk, 
        [EnumMember(Value = "AlpineSki")]
        AlpineSki, 
        [EnumMember(Value = "BackcountrySki")]
        BackcountrySki, 
        [EnumMember(Value = "Canoeing")]
        Canoeing, 
        [EnumMember(Value = "Crossfit")]
        Crossfit, 
        [EnumMember(Value = "EBikeRide")]
        EBikeRide, 
        [EnumMember(Value = "Elliptical")]
        Elliptical, 
        [EnumMember(Value = "Golf")]
        Golf, 
        [EnumMember(Value = "Handcycle")]
        Handcycle, 
        [EnumMember(Value = "IceSkate")]
        IceSkate, 
        [EnumMember(Value = "InlineSkate")]
        InlineSkate, 
        [EnumMember(Value = "Kayaking")]
        Kayaking, 
        [EnumMember(Value = "Kitesurf")]
        Kitesurf, 
        [EnumMember(Value = "NordicSki")]
        NordicSki, 
        [EnumMember(Value = "Pilates")]
        Pilates, 
        [EnumMember(Value = "RockClimbing")]
        RockClimbing, 
        [EnumMember(Value = "RollerSki")]
        RollerSki, 
        [EnumMember(Value = "Rowing")]
        Rowing, 
        [EnumMember(Value = "Sail")]
        Sail, 
        [EnumMember(Value = "Snowboard")]
        Snowboard, 
        [EnumMember(Value = "Snowshoe")]
        Snowshoe, 
        [EnumMember(Value = "Soccer")]
        Soccer, 
        [EnumMember(Value = "Squash")]
        Squash, 
        [EnumMember(Value = "StairStepper")]
        StairStepper, 
        [EnumMember(Value = "StandUpPaddling")]
        StandUpPaddling, 
        [EnumMember(Value = "Surfing")]
        Surfing, 
        [EnumMember(Value = "Tennis")]
        Tennis, 
        [EnumMember(Value = "Transition")]
        Transition, 
        [EnumMember(Value = "Velomobile")]
        Velomobile, 
        [EnumMember(Value = "VirtualRide")]
        VirtualRide, 
        [EnumMember(Value = "VirtualRun")]
        VirtualRun, 
        [EnumMember(Value = "WaterSport")]
        WaterSport, 
        [EnumMember(Value = "Wheelchair")]
        Wheelchair, 
        [EnumMember(Value = "Windsurf")]
        Windsurf, 
        [EnumMember(Value = "Workout")]
        Workout, 
        [EnumMember(Value = "Yoga")]
        Yoga, 
        [EnumMember(Value = "Other")]
        Other
    }
}