using System.Text.Json.Serialization;

namespace Sync.WebModels
{
    public class FitbitUser
    {
        [JsonPropertyName("age")]
        public int Age { get; set; }
        [JsonPropertyName("ambassador")]
        public bool Ambassador { get; set; }
        [JsonPropertyName("autoStrideEnabled")]
        public bool AutoStrideEnabled { get; set; }
        [JsonPropertyName("avatar")]
        public string? Avatar { get; set; }
        [JsonPropertyName("avatar150")]
        public string? Avatar150 { get; set; }
        [JsonPropertyName("avatar640")]
        public string? Avatar640 { get; set; }
        [JsonPropertyName("averageDailySteps")]
        public int AverageDailySteps { get; set; }
        [JsonPropertyName("challengesBeta")]
        public bool ChallengesBeta { get; set; }
        [JsonPropertyName("clockTimeDisplayFormat")]
        public string? ClockTimeDisplayFormat { get; set; } // TODO: enum FitbitProfileTimeFormat
        [JsonPropertyName("corporate")]
        public bool Corporate { get; set; }
        [JsonPropertyName("corporateAdmin")]
        public bool CorporateAdmin { get; set; }
        [JsonPropertyName("country")]
        public string? Country { get; set; }
        [JsonPropertyName("dateOfBirth")]
        public DateTime DateOfBirth { get; set; }
        [JsonPropertyName("displayName")]
        public string? DisplayName { get; set; }
        [JsonPropertyName("displayNameSetting")]
        public FitbitProfileDisplayNameType DisplayNameSetting { get; set; }
        [JsonPropertyName("distanceUnit")]
        public FitbitProfileDistanceUnit DistanceUnit { get; set; }
        [JsonPropertyName("encodedId")]
        public string? EncodedId { get; set; }
        [JsonPropertyName("features")]
        public FitbitProfileFeature? Features { get; set;  }
        [JsonPropertyName("firstName")]
        public string? FirstName { get; set; }
        [JsonPropertyName("foodsLocale")]
        public string? FoodsLocale { get; set; }
        [JsonPropertyName("fullName")]
        public string? FullName { get; set; }
        [JsonPropertyName("gender")]
        public FitbitProfileGender Gender { get; set; }
        [JsonPropertyName("glucoseUnit")]
        public FitbitProfileGlucoseUnit GlucoseUnit { get; set; }
        [JsonPropertyName("height")]
        public double Height { get; set; }
        [JsonPropertyName("heightUnit")]
        public FitbitProfileHeightUnit HeightUnit { get; set; }
        [JsonPropertyName("isBugReportEnabled")]
        public bool IsBugReportEnabled { get; set; }
        [JsonPropertyName("isChild")]
        public bool IsChild { get; set; }
        [JsonPropertyName("isCoach")]
        public bool IsCoach { get; set; }
        [JsonPropertyName("languageLocale")] 
        public FitbitProfileLocale LanguageLocale { get; set; }
        [JsonPropertyName("lastName")]
        public string? LastName { get; set; }
        [JsonPropertyName("legalTermsAcceptRequired")]
        public bool LegalTermsAcceptRequired { get; set; }
        [JsonPropertyName("locale")]
        public FitbitProfileLocale Locale { get; set; }
        [JsonPropertyName("memberSince")]
        public DateTime MemberSince { get; set; }
        [JsonPropertyName("mfaEnabled")]
        public bool MfaEnabled { get; set; }
        [JsonPropertyName("offsetFromUTCMillis")] 
        public int OffsetFromUTCMillis { get; set; }
        [JsonPropertyName("phoneNumber")]
        public string? PhoneNumber { get; set; }
        [JsonPropertyName("sdkDeveloper")]
        public bool SdkDeveloper { get; set; }
        [JsonPropertyName("sleepTracking")]
        public FitbitProfileSleepTrackingType SleepTracking { get; set; }
        [JsonPropertyName("startDayOfWeek")]
        public FitbitProfileStartDayOfWeek StartDayOfWeek { get; set; }
        [JsonPropertyName("strideLengthRunning")]
        public double StrideLengthRunning { get; set; }
        [JsonPropertyName("strideLengthRunningType")]
        public FitbitProfileStrideLengthType StrideLengthRunningType { get; set; }
        [JsonPropertyName("strideLengthWalking")]
        public double StrideLengthWalking { get; set; }
        [JsonPropertyName("strideLengthWalkingType")]
        public FitbitProfileStrideLengthType StrideLengthWalkingType { get; set; }
        [JsonPropertyName("swimUnit")]
        public FitbitProfileSwimUnit SwimUnit { get; set; }
        [JsonPropertyName("temperatureUnit")]
        public FitbitProfileTemperatureUnit TemperatureUnit { get; set; }
        [JsonPropertyName("timezone")]
        public string? Timezone { get; set; }
        [JsonPropertyName("topBadges")]
        public List<FitbitProfileBadge>? TopBadges { get; set; }
        [JsonPropertyName("waterUnit")]
        public FitbitProfileWaterUnit WaterUnit { get; set; }
        [JsonPropertyName("waterUnitName")]
        public string? WaterUnitName { get; set; }
        [JsonPropertyName("weight")]
        public double Weight { get; set; }
        [JsonPropertyName("weightUnit")]
        public FitbitProfileWeightUnit WeightUnit { get; set; }

        public FitbitUser()
        {
        }
    }
}