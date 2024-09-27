using Car.Application.Repositories.Common;
using Car.Domain.Entities.Concretes;

namespace Car.Application.Repositories.Car
{
    public interface IReadVehicleRepository:IReadGenericRepository<Vehicle>
    {
        Task<ICollection<Vehicle>> GetAllVehiclesAsync(int page, int size);

    }
}
