using Car.Application.Repositories.Car;
using Car.Domain.Entities.Concretes;
using Car.Domain.Enums.FuelTypes;
using Car.Domain.Enums.VehicleType;
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

      

        public async Task<(ICollection<Vehicle> Vehicles, int TotalCount)> GetAllVehiclesAsync(
             int page,
             int size,
             string? brand = null,
             VehicleType? vehicleType = null,
             FuelType? fuelType = null)
        {
            var query = _table.AsQueryable();

            if (!string.IsNullOrEmpty(brand))
                query = query.Where(v => v.Brand == brand);

            if (vehicleType.HasValue)
                query = query.Where(v => v.VehicleType == vehicleType.Value);

            if (fuelType.HasValue)
                query = query.Where(v => v.FuelType == fuelType.Value);

            var totalCount = await query.CountAsync();

            var vehicles = await query
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync();

            return (vehicles, totalCount);
        }

     

        
    }
}
