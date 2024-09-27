using Car.Application.Repositories.Common;
using Car.Domain.Entities.Concretes;

namespace Car.Application.Repositories
{
    public interface IReadUserRepository:IReadGenericRepository<User>
    {
        Task<User?> GetUserByEmail(string email);
        Task<User?> GetUserByUserName(string userName);
    }
}
