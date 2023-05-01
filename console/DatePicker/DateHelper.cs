namespace Sync.Enumerator
{
    internal static class DateHelper
    {
        private const int MaxAllowedNumOfDays = 30;
        
        public static void ThrowIfDateInvalid(DateTime value)
        {
            var allowedDate = DateTime.Today.AddDays(-MaxAllowedNumOfDays);
            if (value < allowedDate)
                throw new InvalidOperationException($"The specified date {value} must be no less than {allowedDate}");
            if (value > DateTime.Today)
                throw new InvalidOperationException($"The specified date {value} cannot be greater than the current date.");
        }
    }
}