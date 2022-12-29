namespace Sync.Utilities
{
    [Serializable]
    public class ApiRequestException : Exception
    {
        public ApiRequestException()
        {
        }

        public ApiRequestException(string message)
            : base(message)
        {
        }

        public ApiRequestException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}