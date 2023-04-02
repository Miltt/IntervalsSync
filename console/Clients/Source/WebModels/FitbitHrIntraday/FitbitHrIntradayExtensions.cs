namespace Sync.WebModels
{
    public static class FitbitHrIntradayExtensions
    {
        public static string ToDto(this FitbitHrIntradayDetailLevel value)
        {
            switch (value)
            {
                case FitbitHrIntradayDetailLevel.OneSec:
                    return "1sec";
                case FitbitHrIntradayDetailLevel.FiveMin:
                    return "5min";
                case FitbitHrIntradayDetailLevel.FifteenMin:
                    return "15min";
                case FitbitHrIntradayDetailLevel.OneMin:
                default:
                    return "1min";
            }
        }
    }
}