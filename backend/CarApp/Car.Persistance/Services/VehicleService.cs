using Car.Application.Repositories.Car;
using Car.Application.Services;
using Car.Domain.DTO_s;
using Car.Domain.Entities.Concretes;
using System.Net;

namespace Car.Persistance.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IReadVehicleRepository _readVehicleRepository;
        private readonly IWriteVehicleRepository _writeVehicleRepository;

        public VehicleService(
            IReadVehicleRepository readVehicleRepository,
            IWriteVehicleRepository writeVehicleRepository)
        {
            _readVehicleRepository = readVehicleRepository;
            _writeVehicleRepository = writeVehicleRepository;
        }
        public async Task AddVehicleAsync(VehicleDTO vehicleDTO, string userId)
        {
            var vehicle = new Vehicle
            {
                Brand = vehicleDTO.Brand,
                Model = vehicleDTO.Model,
                Year = vehicleDTO.Year,
                ImgUrl = vehicleDTO.ImgUrl,
                UserId=userId
            };
            await _writeVehicleRepository.AddAsync(vehicle);
        }

        public async Task<ICollection<Vehicle>> GetVehicleAsync(int page,int size)
        {
            var vehicles = await _readVehicleRepository.GetAllVehiclesAsync(page,size);
            var vehicleDto = vehicles.Select(p=>new Vehicle
            {
                Id=p.Id,
                Brand = p.Brand,
                Model = p.Model,
                Year = p.Year,
                ImgUrl = p.ImgUrl,
            }).ToList();
            return vehicleDto;
        }

        public async Task RemoveVehicleAsync(string vehicleId)
        {
            await _writeVehicleRepository.DeleteAsync(vehicleId);
        }

        public async Task UpdateVehicleAsync(UpdateVehicleDTO vehicleDTO, string userId)
        {
            var vehicle = new Vehicle
            {
                Id = vehicleDTO.Id,
                Brand = vehicleDTO.Brand,
                Model = vehicleDTO.Model,
                Year = vehicleDTO.Year,
                ImgUrl = vehicleDTO.ImgUrl,
                UserId=userId
            };
            await _writeVehicleRepository.UpdateAsync(vehicle);
        }
    }
}
