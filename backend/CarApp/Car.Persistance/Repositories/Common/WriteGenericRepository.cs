using Car.Application.Repositories.Common;
using Car.Domain.Entities.Abstracts;
using Car.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Car.Persistance.Repositories.Common
{
    public class WriteGenericRepository<T> : GenericRepository<T>, IWriteGenericRepository<T> where T : class, IBaseEntity, new()
    {
        public WriteGenericRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(T entity)
        {
            _table.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddRangesAsync(IEnumerable<T> entities)
        {
            await _table.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _table.Remove(entity); 
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await _table.FirstOrDefaultAsync(p => p.Id == id);
            if (entity != null)
                _table.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _table.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
