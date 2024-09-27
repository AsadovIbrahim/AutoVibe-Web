using Car.Application.Repositories.Common;
using Car.Domain.Entities.Concretes;

namespace Car.Application.Repositories
{
    public interface IWriteUserRepository:IWriteGenericRepository<User>
    {
    }
}
