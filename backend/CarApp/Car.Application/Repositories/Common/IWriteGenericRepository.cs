using Car.Domain.Entities.Abstracts;

namespace Car.Application.Repositories.Common
{
    public interface IWriteGenericRepository<T>:IGenericRepository<T>where T : class,IBaseEntity,new()
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteAsync(string id);
        Task AddRangesAsync(IEnumerable<T> entities);
        Task SaveChangesAsync();
    }
}
