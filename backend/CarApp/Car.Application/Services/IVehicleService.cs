using Car.Domain.DTO_s;
using Car.Domain.Entities.Concretes;

namespace Car.Application.Services
{
    public interface IVehicleService
    {
        Task AddVehicleAsync(VehicleDTO vehicleDTO,string userId);
        Task RemoveVehicleAsync(string vehicleId);
        Task<ICollection<Vehicle>> GetVehicleAsync(int page,int size);
        Task<Vehicle> GetVehicleByIdAsync(string vehicleId);
        Task UpdateVehicleAsync(UpdateVehicleDTO vehicleDTO,string userId);
    }
}
