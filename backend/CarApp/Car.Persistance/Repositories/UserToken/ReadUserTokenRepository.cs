using Car.Application.Repositories;
using Car.Domain.Entities.Concretes;
using Car.Persistance.Contexts;
using Car.Persistance.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace Car.Persistance.Repositories
{
    internal class ReadUserTokenRepository : ReadGenericRepository<UserToken>, IReadUserTokenRepository
    {
        public ReadUserTokenRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<User?> GetUserByRefreshToken(string refreshToken)
        {
            return await _table.Where(x => x.Name == "RefreshToken" && !x.IsDeleted && x.Token == refreshToken).Select(p => p.User).FirstOrDefaultAsync();
        }

        public async Task<User?> GetUserByRePasswordToken(string rePasswordToken)
        {
            return await _table.Where(x => x.Token == rePasswordToken && x.Name == "RepasswordToken" && !x.IsDeleted).Select(p => p.User).FirstOrDefaultAsync();
        }

        public async Task<User?> GetUserByConfirmEmailToken(string confirmEmailToken)
        {
            return await _table.Where(x => x.Name == "ConfirmEmailToken" && !x.IsDeleted && x.Token == confirmEmailToken).Select(p => p.User).FirstOrDefaultAsync();
        }

        public async Task<UserToken?> GetConfirmEmailToken(string token)
        {
            return await _table.Where(x => x.Name == "ConfirmEmailToken" && !x.IsDeleted && x.Token == token).FirstOrDefaultAsync();
        }

        public async Task<UserToken?> GetResetPasswordToken(string token)
        {
            return await _table.Where(x => x.Name == "RepasswordToken" && !x.IsDeleted && x.Token == token).FirstOrDefaultAsync();
        }
    }
}
