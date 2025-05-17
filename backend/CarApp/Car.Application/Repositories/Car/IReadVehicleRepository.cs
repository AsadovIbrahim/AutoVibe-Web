using Car.Application.Repositories.Common;
using Car.Domain.DTO_s;
using Car.Domain.Entities.Concretes;
using Car.Domain.Enums.FuelTypes;
using Car.Domain.Enums.VehicleType;

namespace Car.Application.Repositories.Car
{
    public interface IReadVehicleRepository : IReadGenericRepository<Vehicle>
    {

        Task<ICollection<Vehicle>> GetAllVehiclesListAsync();
        Task<(ICollection<Vehicle>Vehicles,int TotalCount)>GetRelatedVehiclesAsync(VehicleType? vehicleType, FuelType? fuelType, string excludedVehicleId, int page, int size);
        Task<(ICollection<Vehicle> Vehicles, int TotalCount)> GetAllVehiclesAsync(
                     int page,  
                     int size,
                     string? brand = null,
                     VehicleType? vehicleType = null,
                     FuelType? fuelType = null);

    }
}
