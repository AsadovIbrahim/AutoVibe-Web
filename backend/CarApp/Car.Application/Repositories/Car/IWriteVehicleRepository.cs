using Car.Application.Repositories.Common;
using Car.Domain.Entities.Concretes;

namespace Car.Application.Repositories.Car
{
    public interface IWriteVehicleRepository:IWriteGenericRepository<Vehicle>
    {
    }
}
