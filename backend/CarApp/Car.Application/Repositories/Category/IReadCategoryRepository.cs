using Car.Domain.Entities.Concretes;
using Car.Application.Repositories.Common;

namespace Car.Application.Repositories
{
    public interface IReadCategoryRepository:IReadGenericRepository<Category>
    {
        Task<ICollection<Category>> GetAllCategories(int page, int size);
        string GetCategoryNameById(string id);
    }
}
