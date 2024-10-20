using Car.Domain.DTO_s;
using Car.Domain.Entities.Concretes;

namespace Car.Application.Services
{
    public interface ICategoryService
    {
        Task AddCategoryAsync(AddCategoryDTO addcategoryDTO,string userId);
        Task RemoveCategoryAsync(string categoryId);
        Task<ICollection<Category>> GetCategoriesAsync(int page, int size);
        Task<Category> GetCategoryByIdAsync(string categoryId);
        Task UpdateCategoryAsync(UpdateCategoryDTO updateCategoryDTO, string userId);
    }
}
