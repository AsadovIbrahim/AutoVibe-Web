using Car.Application.Repositories.Car;
using Car.Domain.Entities.Concretes;
using Car.Persistance.Contexts;
using Car.Persistance.Repositories.Common;

namespace Car.Persistance.Repositories
{
    public class WriteVehicleRepository : WriteGenericRepository<Vehicle>, IWriteVehicleRepository
    {
        public WriteVehicleRepository(AppDbContext context) : base(context)
        {
        }
    }
}
