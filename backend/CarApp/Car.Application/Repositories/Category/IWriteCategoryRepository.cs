using Car.Domain.Entities.Concretes;
using Car.Application.Repositories.Common;

namespace Car.Application.Repositories
{
    public interface IWriteCategoryRepository:IWriteGenericRepository<Category>
    {
    }
}
