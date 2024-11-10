using Car.Domain.DTO_s;
using Car.Application.Services;
using Car.Domain.Entities.Concretes;
using Car.Application.Repositories.Car;
using Car.Domain.Enums.FuelTypes;
using Car.Domain.Enums.VehicleType;

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
                FuelType = Enum.Parse<FuelType>(vehicleDTO.FuelType, true), 
                VehicleType = Enum.Parse<VehicleType>(vehicleDTO.VehicleType, true), 
                ImgUrl = vehicleDTO.ImgUrl,
                UserId=userId
            };
            await _writeVehicleRepository.AddAsync(vehicle);
        }

        public async Task<ICollection<GetVehicleDTO>> GetVehicleAsync(int page,int size,string? brand=null,VehicleType?vehicleType=null,FuelType?fuelType=null)
        {
            var vehicles = await _readVehicleRepository.GetAllVehiclesAsync(page,size);

            if (!string.IsNullOrEmpty(brand))
                vehicles=vehicles.Where(v=>v.Brand==brand).ToList();

            if (vehicleType.HasValue)
                vehicles=vehicles.Where(v=>v.VehicleType== vehicleType.Value).ToList();

            if (fuelType.HasValue)
                vehicles=vehicles.Where(v=>v.FuelType== fuelType.Value).ToList();

            var vehicleDto = vehicles.Select(p=>new GetVehicleDTO
            {
                Id=p.Id,
                Brand = p.Brand,
                Model = p.Model,
                Year = p.Year,
                FuelType = p.FuelType.ToString(),
                VehicleType = p.VehicleType.ToString(),
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
                FuelType = Enum.Parse<FuelType>(vehicleDTO.FuelType, true),  
                VehicleType = Enum.Parse<VehicleType>(vehicleDTO.VehicleType, true),
                Year = vehicleDTO.Year,
                ImgUrl = vehicleDTO.ImgUrl,
                UserId=userId
            };
            await _writeVehicleRepository.UpdateAsync(vehicle);
        }
        public async Task<GetVehicleDTO> GetVehicleByIdAsync(string vehicleId)
        {
            var selectedVehicle=await _readVehicleRepository.GetByIdAsync(vehicleId);
            var result = new GetVehicleDTO
            {
                Id=selectedVehicle!.Id,
                Brand = selectedVehicle.Brand,
                Model = selectedVehicle.Model,
                FuelType =selectedVehicle.FuelType.ToString(),
                VehicleType =selectedVehicle.VehicleType.ToString(),       
                Year = selectedVehicle.Year,
                ImgUrl = selectedVehicle.ImgUrl,
            };
            return result;
        }

        public async Task ClearAllVehicles()
        {
            var vehicles=await _readVehicleRepository.GetAllAsync();
            foreach (var vehicle in vehicles) { 
                await _writeVehicleRepository.DeleteAsync(vehicle);
            }
        }

    }
}
