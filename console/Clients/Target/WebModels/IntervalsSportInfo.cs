using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    public class IntervalsSportInfo
    {
        [JsonPropertyName("type")]
        public IntervalsType? Type { get; set; }
        [JsonPropertyName("eftp")]
        public double? Eftp { get; set; }

        public IntervalsSportInfo()
        {
        }
    }
}