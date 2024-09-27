using Car.Domain.Helpers;
using Car.Domain.Entities.Concretes;

namespace Car.Application.Services
{
    public interface ITokenService
    {
        TokenCredentials CreateRefreshToken();
        TokenCredentials CreateConfirmEmailToken();
        Task<TokenCredentials> CreateAccessToken(User user);
        Task<TokenCredentials> CreateRepasswordToken(User user);
    }
}
