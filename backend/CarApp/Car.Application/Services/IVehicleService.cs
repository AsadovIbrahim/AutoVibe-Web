using Car.Domain.DTO_s;
using Car.Domain.Enums.FuelTypes;
using Car.Domain.Enums.VehicleType;

namespace Car.Application.Services
{
    public interface IVehicleService
    {
        Task ClearAllVehicles();
        Task RemoveVehicleAsync(string vehicleId);
        Task AddVehicleAsync(VehicleDTO vehicleDTO,string userId);
        Task<GetVehicleDTO> GetVehicleByIdAsync(string vehicleId);
        Task UpdateVehicleAsync(UpdateVehicleDTO vehicleDTO,string userId);
        Task<ICollection<GetVehicleDTO>> GetRelatedVehiclesAsync(string vehicleId);
        Task<ICollection<GetVehicleDTO>> GetAllVehiclesListAsync();
        Task<(ICollection<GetVehicleDTO> Vehicles, int TotalCount)> GetVehicleAsync(
           int page,
           int size,
           string? brand = null,
           VehicleType? vehicleType = null,
           FuelType? fuelType = null);  
    }
}
