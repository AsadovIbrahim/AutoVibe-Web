using Car.Application.Repositories;
using Car.Domain.Entities.Concretes;
using Car.Persistance.Contexts;
using Car.Persistance.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace Car.Persistance.Repositories
{
    public class ReadCategoryRepository : ReadGenericRepository<Category>, IReadCategoryRepository
    {
        public ReadCategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<ICollection<Category>> GetAllCategories(int page, int size)
        {
            return await _table.Skip((page - 1) * size)
                            .Take(size)
                            .ToListAsync();
        }

        public string GetCategoryNameById(string id)
        {
            var category = _context.Categories.FirstOrDefault(p => p.Id == id);
            return category?.Name ?? "Unknown Category";
        }
    }
}
