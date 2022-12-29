namespace Sync.Utilities
{
    [Serializable]
    public class IntervalsSyncException : Exception
    {
        public IntervalsSyncException()
        {
        }

        public IntervalsSyncException(string message)
            : base(message)
        {
        }

        public IntervalsSyncException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}