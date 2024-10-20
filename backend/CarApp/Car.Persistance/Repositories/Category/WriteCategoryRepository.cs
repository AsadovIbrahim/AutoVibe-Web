using Car.Application.Repositories;
using Car.Domain.Entities.Concretes;
using Car.Persistance.Contexts;
using Car.Persistance.Repositories.Common;

namespace Car.Persistance.Repositories
{
    public class WriteCategoryRepository : WriteGenericRepository<Category>, IWriteCategoryRepository
    {
        public WriteCategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
