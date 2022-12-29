using System.Net;

namespace Sync.Utilities
{
    public static class Extensions
    {
        private const string WebApiFormat = "yyyy-MM-dd";

        public static string ToWebApiFormat(this DateTime value)
        {
            return value.ToString(WebApiFormat);
        }

        public static async Task VerifyResponseAsync(this HttpResponseMessage response)
        {
            if (response is null)
                throw new ArgumentNullException(nameof(response));

            if (!response.IsSuccessStatusCode)
            {
                var errors = await response.Content.ReadAsStringAsync();

                switch (response.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.Unauthorized:
                    case HttpStatusCode.Forbidden:
                    case HttpStatusCode.NotFound:
                        throw new ApiRequestException(errors);
                }

                throw new IntervalsSyncException($"An error has occured. {response.StatusCode}: {errors}");
            }
        }

        public static void WaitAndUnwrapException(this Task task)
        {
            if (task is null)
                throw new ArgumentNullException(nameof(task));

            task.GetAwaiter().GetResult();
        }
    }
}