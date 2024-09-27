using Car.Domain.Entities.Abstracts;

namespace Car.Application.Repositories.Common
{
    public interface IGenericRepository<T>where T : class,IBaseEntity,new()
    {
    }
}
