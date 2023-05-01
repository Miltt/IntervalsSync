using System.Collections;

namespace Sync.Enumerator
{
    internal sealed class DatePicker : IEnumerable<DateTime>
    {
        private readonly DateTime _value;

        public DatePicker(DateTime value)
        {
            DateHelper.ThrowIfDateInvalid(value);

            _value = value;
        }

        public IEnumerator<DateTime> GetEnumerator()
        {
            return new DateEnumerator(_value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}