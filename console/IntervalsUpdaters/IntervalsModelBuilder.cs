using Sync.WebModels;

namespace Sync.IntervalsUpdaters
{
    public sealed class IntervalsModelBuilder
    {
        private enum SleepQualityScore
        {
            Great = 1,
            Good = 2,
            Avg = 3,
            Poor = 4
        }

        private const int GreatSleepQuality = 85;
        private const int GoodSleepQuality = 80;
        private const int AvgSleepQuality = 70;

        public void BuildWellness(IntervalsWellness? intervalWellness, FitbitDataCollector.Wellness wellnessData, 
            ExternalDataCollector.Data data)
        {
            if (intervalWellness is null)
                throw new ArgumentNullException(nameof(intervalWellness));

            intervalWellness.SpO2 = wellnessData.SpO2?.Value?.Avg;
            intervalWellness.Hrv = wellnessData.Hrv?.Values?.FirstOrDefault()?.Rmssd?.DailyRmssd;
            intervalWellness.RestingHR = wellnessData.HrTimeSeries?.HrActivities?.FirstOrDefault()?.ActivitiesValue?.RestingHeartRate;

            var fitbitSleepSummary = wellnessData.SleepLog?.Summary;
            if (fitbitSleepSummary != null)
            {
                intervalWellness.SleepSecs = fitbitSleepSummary.TotalMinutesAsleep * 60;

                if (TryCalcSleepScore(
                    totalTimeInBed: fitbitSleepSummary.TotalTimeInBed,
                    totalMinutesAsleep: fitbitSleepSummary.TotalMinutesAsleep,
                    score: out var sleepScore) && sleepScore.HasValue)
                {
                    intervalWellness.SleepScore = Math.Round(sleepScore.Value, 1);
                    intervalWellness.SleepQuality = (int?)GetSleepQuality(sleepScore);
                }
            }

            intervalWellness.AvgSleepingHR = GetAvgSleepingHR(wellnessData.HrIntradaySeries);
            intervalWellness.Readiness = GetReadiness();
            intervalWellness.BodyFat = data.BodyFat;
            intervalWellness.Weight = data.Weight;
            intervalWellness.Vo2max = data.Vo2Max;
            intervalWellness.Comments = $"Updated by Fitbit values {DateTime.UtcNow}";
        }

        public void BuildCalories(IntervalsWellness? intervalWellness, FitbitDataCollector.Wellness wellnessData)
        {
            if (intervalWellness is null)
                throw new ArgumentNullException(nameof(intervalWellness));
            
            intervalWellness.KcalConsumed = (int?)wellnessData.FoodLog?.Summary?.Calories;
        }

        private bool TryCalcSleepScore(int totalTimeInBed, int totalMinutesAsleep, out double? score)
        {
            score = null;

            if (totalMinutesAsleep < totalTimeInBed && totalTimeInBed > 0)
                score = (double)totalMinutesAsleep / totalTimeInBed * 100;

            return score != null;
        }

        private SleepQualityScore? GetSleepQuality(double? value)
        {
            if (value < AvgSleepQuality)
                return SleepQualityScore.Poor;
            if (value >= AvgSleepQuality && value < GoodSleepQuality)
                return SleepQualityScore.Avg;
            if (value >= GoodSleepQuality && value < GreatSleepQuality)
                return SleepQualityScore.Good;
            if (value >= GreatSleepQuality)
                return SleepQualityScore.Great;

            return null;
        }

        private double? GetAvgSleepingHR(FitbitHrIntradaySeries? hrIntradaySeries)
        {
            var items = hrIntradaySeries?.ActivitiesIntraday?.Dataset;

            return items?.Count > 0
                ? Math.Round(items.Average(i => i.Value), 2)
                : null;
        }

        private double? GetReadiness()
        {
            // TODO: activity + recent sleep + hrv
            return null;
        }
    }
}