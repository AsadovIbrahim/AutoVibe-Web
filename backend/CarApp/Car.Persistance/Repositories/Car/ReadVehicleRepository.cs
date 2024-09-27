using Car.Application.Repositories.Car;
using Car.Domain.Entities.Concretes;
using Car.Persistance.Contexts;
using Car.Persistance.Repositories.Common;  
using Microsoft.EntityFrameworkCore;

namespace Car.Persistance.Repositories
{
    public class ReadVehicleRepository : ReadGenericRepository<Vehicle>, IReadVehicleRepository
    {
        public ReadVehicleRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<ICollection<Vehicle>> GetAllVehiclesAsync(int page, int size)
        {
            return await _table.Skip((page - 1) * size)
                .Take(size)
                .ToListAsync();
        }
    }
}
