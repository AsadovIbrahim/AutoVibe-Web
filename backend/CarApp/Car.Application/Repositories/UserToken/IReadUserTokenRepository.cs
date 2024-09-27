using Car.Application.Repositories.Common;
using Car.Domain.Entities.Concretes;

namespace Car.Application.Repositories
{
    public interface IReadUserTokenRepository : IReadGenericRepository<UserToken>
    {
        Task<UserToken?> GetConfirmEmailToken(string token);
        Task<UserToken?> GetResetPasswordToken(string token);
        Task<User?> GetUserByRefreshToken(string refreshToken);
        Task<User?> GetUserByRePasswordToken(string rePasswordToken);
        Task<User?> GetUserByConfirmEmailToken(string confirmEmailToken);
    }
}
