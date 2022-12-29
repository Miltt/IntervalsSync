using Sync.WebModels;

namespace Sync
{
    public interface IFitbitTokenManager
    {
        Task<FitbitOAuth2AccessToken> GetTokenAsync(CancellationToken cancellationToken);
    }
}