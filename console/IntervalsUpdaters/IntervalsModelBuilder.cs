using Sync.WebModels;

namespace Sync.IntervalsUpdaters
{
    public sealed class IntervalsModelBuilder
    {
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
                    intervalWellness.SleepQuality = GetSleepQuality(sleepScore);
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
            
            intervalWellness.KcalConsumed = wellnessData.FoodLog?.Summary?.Calories;
        }

        private bool TryCalcSleepScore(int totalTimeInBed, int totalMinutesAsleep, out double? score)
        {
            score = null;

            if (totalMinutesAsleep < totalTimeInBed && totalTimeInBed > 0)
                score = (double)totalMinutesAsleep / totalTimeInBed * 100;

            return score != null;
        }

        private int? GetSleepQuality(double? value)
        {
            // TODO:
            if (value < 25)
                return 4;
            if (value >= 25 && value < 50)
                return 3;
            if (value >= 50 && value < 75)
                return 2;
            if (value >= 75)
                return 1;
            
            return null;
        }

        private double? GetAvgSleepingHR(FitbitHrIntradaySeries? hrIntradaySeries)
        {
            var items = hrIntradaySeries?.ActivitiesIntraday?.Dataset;

            return items?.Count > 0
                ? items.Average(i => i.Value)
                : (double?)null;
        }

        private double? GetReadiness()
        {
            // TODO: 
            return null;
        }
    }
}