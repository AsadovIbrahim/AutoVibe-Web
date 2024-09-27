using Car.Application.Repositories.Common;
using Car.Domain.Entities.Abstracts;
using Car.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Car.Persistance.Repositories.Common
{
    public class ReadGenericRepository<T> : GenericRepository<T>, IReadGenericRepository<T> where T : class, IBaseEntity, new()
    {
        public ReadGenericRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _table.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(string id)
        {
            return await _table.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
