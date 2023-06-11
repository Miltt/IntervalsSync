using System.Collections;

namespace Sync.Enumerator
{
    internal sealed class DateEnumerator : IEnumerator<DateTime>
    {
        private readonly DateTime _value;
        private DateTime _current;
        private int _days;

        public DateTime Current => _current;
        object IEnumerator.Current => this.Current;

        public DateEnumerator(DateTime value)
        {
            DateHelper.ThrowIfDateInvalid(value);

            _value = value;
            _current = default(DateTime);
            _days = 0;
        }

        public bool MoveNext()
        {
            _days++;
            _current = _value.AddDays(_days);

            return _current <= DateTime.Today;
        }

        public void Reset()
        {
            _current = default(DateTime);
            _days = 0;
        }

        public void Dispose()
        {
        }
    }
}