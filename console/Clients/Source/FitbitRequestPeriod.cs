using System.ComponentModel;

namespace Sync
{
    public enum FitbitRequestPeriod
    {
        [Description("1d")]
        OneDay,
        [Description("7d")]
        SevenDay,
        [Description("30d")]
        ThirtyDays,
        [Description("1w")]
        OneWeek,
        [Description("1m")]
        OneMonth
    }
}