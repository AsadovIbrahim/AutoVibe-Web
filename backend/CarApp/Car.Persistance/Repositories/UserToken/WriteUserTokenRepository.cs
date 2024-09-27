using Car.Application.Repositories;
using Car.Domain.Entities.Concretes;
using Car.Persistance.Contexts;
using Car.Persistance.Repositories.Common;

namespace Car.Persistance.Repositories
{
    public class WriteUserTokenRepository : WriteGenericRepository<UserToken>, IWriteUserTokenRepository
    {
        public WriteUserTokenRepository(AppDbContext context) : base(context)
        {
        }
    }
}
