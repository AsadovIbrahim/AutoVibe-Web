using Car.Domain.DTO_s;
using Car.Application.Services;
using Car.Domain.Entities.Concretes;
using Car.Application.Repositories;

namespace Car.Persistance.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IReadCategoryRepository _readCategoryRepository;
        private readonly IWriteCategoryRepository _writeCategoryRepository;

        public CategoryService(IReadCategoryRepository readCategoryRepository, IWriteCategoryRepository writeCategoryRepository)
        {
            _readCategoryRepository = readCategoryRepository;
            _writeCategoryRepository = writeCategoryRepository;
        }
        public async Task AddCategoryAsync(AddCategoryDTO addcategoryDTO, string userId)
        {
            bool exist = false;
            foreach (var item in await _readCategoryRepository.GetAllAsync())
            {
                if (item.Name == addcategoryDTO.Name)
                {
                    exist = true;
                }
            }
            if (!exist)
            {
                var category = new Category
                {
                    Name = addcategoryDTO.Name,
                };
                await _writeCategoryRepository.AddAsync(category);
            }
        }
        public async Task<ICollection<Category>> GetCategoriesAsync(int page, int size)
        {
            var category = await _readCategoryRepository.GetAllCategories(page, size);
            var result = category.Select(p => new Category
            {
                Id = p.Id,
                Name = p.Name,
            }).ToList();
            return result;
        }

        public async Task<Category> GetCategoryByIdAsync(string categoryId)
        {
            var selectedCategory = await _readCategoryRepository.GetByIdAsync(categoryId);
            var category = new Category
            {
                Id = selectedCategory.Id,
                Name = selectedCategory.Name,
            };
            return category;
        }

        public async Task RemoveCategoryAsync(string categoryId)
        {
            await _writeCategoryRepository.DeleteAsync(categoryId);
        }
        public async Task UpdateCategoryAsync(UpdateCategoryDTO updateCategoryDTO, string userId)
        {
            var updateCategory = new Category
            {
                Id = updateCategoryDTO.Id,
                Name = updateCategoryDTO.Name,
            };
            await _writeCategoryRepository.UpdateAsync(updateCategory);
        }
    }
}
