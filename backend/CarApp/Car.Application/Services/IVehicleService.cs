using Car.Domain.DTO_s;

namespace Car.Application.Services
{
    public interface IVehicleService
    {
        Task AddVehicleAsync(VehicleDTO vehicleDTO,string userId);
        Task RemoveVehicleAsync(string vehicleId);
        Task<ICollection<GetVehicleDTO>> GetVehicleAsync(int page,int size);
        Task<GetVehicleDTO> GetVehicleByIdAsync(string vehicleId);
        Task UpdateVehicleAsync(UpdateVehicleDTO vehicleDTO,string userId);
        Task ClearAllVehicles();
    }
}
