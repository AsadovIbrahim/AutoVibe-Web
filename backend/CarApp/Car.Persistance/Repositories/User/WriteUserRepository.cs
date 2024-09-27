using Car.Application.Repositories;
using Car.Domain.Entities.Concretes;
using Car.Persistance.Contexts;
using Car.Persistance.Repositories.Common;

namespace Car.Persistance.Repositories
{
    public class WriteUserRepository : WriteGenericRepository<User>, IWriteUserRepository
    {
        public WriteUserRepository(AppDbContext context) : base(context)
        {
        }
    }
}
