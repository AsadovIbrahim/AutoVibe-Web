using Car.Application.Repositories.Common;
using Car.Domain.Entities.Abstracts;
using Car.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Car.Persistance.Repositories.Common
{
    public class GenericRepository<T>:IGenericRepository<T>where T : class,IBaseEntity,new()
    {
        protected DbSet<T> _table;
        protected readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _table = _context.Set <T>();
        }

    }
}
