using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    public class FitbitHrIntradaySeries
    {
        [JsonPropertyName("activities-heart")]
        public List<FitbitHrIntradaySeriesHeart>? Activities { get; set; }

        [JsonPropertyName("activities-heart-intraday")]
        public FitbitHrIntradaySeriesHeartIntraday? ActivitiesIntraday { get; set; }
    }
}