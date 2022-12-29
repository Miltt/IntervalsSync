using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    public class FitbitProfileBadge
    {
        [JsonPropertyName("badgeGradientEndColor")]
        public string? BadgeGradientEndColor { get; set; }
        [JsonPropertyName("badgeGradientStartColor")]
        public string? BadgeGradientStartColor { get; set; }
        [JsonPropertyName("badgeType")]
        public string? BadgeType { get; set; } // TODO: enum FitbitProfileBadgeType
        [JsonPropertyName("category")]
        public string? Category { get; set; }
        [JsonPropertyName("cheers")]
        public List<string>? Cheers { get; set; }
        [JsonPropertyName("dateTime")]
        public DateTime DateTime { get; set; }
        [JsonPropertyName("description")]
        public string? Description { get; set; }
        [JsonPropertyName("earnedMessage")]
        public string? EarnedMessage { get; set; }
        [JsonPropertyName("encodedId")]
        public string? EncodedId { get; set; }
        [JsonPropertyName("image100px")]
        public string? Image100px { get; set; }
        [JsonPropertyName("image125px")]
        public string? Image125px { get; set; }
        [JsonPropertyName("image300px")]
        public string? Image300px { get; set; }
        [JsonPropertyName("image50px")]
        public string? Image50px { get; set; }
        [JsonPropertyName("image75px")]
        public string? Image75px { get; set; }
        [JsonPropertyName("marketingDescription")]
        public string? MarketingDescription { get; set; }
        [JsonPropertyName("mobileDescription")]
        public string? MobileDescription { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("shareImage640px")]
        public string? ShareImage640px { get; set; }
        [JsonPropertyName("shareText")]
        public string? ShareText { get; set; }
        [JsonPropertyName("shortDescription")]
        public string? ShortDescription { get; set; }
        [JsonPropertyName("shortName")]
        public string? ShortName { get; set; }
        [JsonPropertyName("timesAchieved")]
        public int TimesAchieved { get; set; }
        [JsonPropertyName("value")]
        public int Value { get; set; }

        public FitbitProfileBadge()
        {
        }
    }
}