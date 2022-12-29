using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    public class FitbitOAuth2AccessToken
    {
        [JsonPropertyName("access_token")]
        public string? Token { get; set; }
        [JsonPropertyName("token_type")]
        public string? TokenType { get; set; }
        [JsonPropertyName("scope")]
        public string? Scope { get; set; }
        [JsonPropertyName("expires_in")]
        public int? ExpiresIn { get; set; }
        [JsonPropertyName("refresh_token")]
        public string? RefreshToken { get; set; }
        [JsonPropertyName("user_id")]
        public string? UserId { get; set; }
        public DateTime ExpirationDateUtc { get; set; }

        public FitbitOAuth2AccessToken()
        {
        }

        public bool IsFresh()
        {
            return ExpirationDateUtc > DateTime.UtcNow;
        }

        public void SetExpirationDate()
        {
            if (ExpiresIn.HasValue && ExpiresIn.Value > 0)
                ExpirationDateUtc = DateTime.UtcNow.AddSeconds(ExpiresIn.Value);  
        }
    }
}