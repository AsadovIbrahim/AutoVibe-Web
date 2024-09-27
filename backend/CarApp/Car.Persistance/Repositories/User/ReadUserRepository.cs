using Car.Application.Repositories;
using Car.Domain.Entities.Concretes;
using Car.Persistance.Contexts;
using Car.Persistance.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace Car.Persistance.Repositories
{
    public class ReadUserRepository : ReadGenericRepository<User>, IReadUserRepository
    {
        public ReadUserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _table.FirstOrDefaultAsync(e=>e.Email == email);
        }

        public async Task<User?> GetUserByUserName(string userName)
        {
            return await _table.FirstOrDefaultAsync(u=>u.UserName == userName);
        }
    }
}
