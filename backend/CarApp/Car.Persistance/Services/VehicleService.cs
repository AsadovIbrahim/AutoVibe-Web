using Car.Domain.DTO_s;
using Car.Application.Services;
using Car.Application.Repositories;
using Car.Domain.Entities.Concretes;
using Car.Application.Repositories.Car;

namespace Car.Persistance.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IReadVehicleRepository _readVehicleRepository;
        private readonly IWriteVehicleRepository _writeVehicleRepository;
        private readonly IReadCategoryRepository _readCategoryRepository;

        public VehicleService(
            IReadVehicleRepository readVehicleRepository,
            IWriteVehicleRepository writeVehicleRepository,
            IReadCategoryRepository readCategoryRepository)
        {
            _readVehicleRepository = readVehicleRepository;
            _writeVehicleRepository = writeVehicleRepository;
            _readCategoryRepository = readCategoryRepository;
        }
        public async Task AddVehicleAsync(VehicleDTO vehicleDTO, string userId)
        {
            var vehicle = new Vehicle
            {
                Brand = vehicleDTO.Brand,
                Model = vehicleDTO.Model,
                Year = vehicleDTO.Year,
                ImgUrl = vehicleDTO.ImgUrl,
                CategoryId=vehicleDTO.CategoryId,
                UserId=userId
            };
            await _writeVehicleRepository.AddAsync(vehicle);
        }

        public async Task<ICollection<GetVehicleDTO>> GetVehicleAsync(int page,int size)
        {
            var vehicles = await _readVehicleRepository.GetAllVehiclesAsync(page,size);
            var vehicleDto = vehicles.Select(p=>new GetVehicleDTO
            {
                Id=p.Id,
                Brand = p.Brand,
                Model = p.Model,
                Year = p.Year,
                CategoryName=_readCategoryRepository.GetCategoryNameById(p.CategoryId),
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
                CategoryId=vehicleDTO.CategoryId,
                ImgUrl = vehicleDTO.ImgUrl,
                UserId=userId
            };
            await _writeVehicleRepository.UpdateAsync(vehicle);
        }
        public async Task<Vehicle> GetVehicleByIdAsync(string vehicleId)
        {
            var selectedVehicle=await _readVehicleRepository.GetByIdAsync(vehicleId);
            var result = new Vehicle
            {
                Id=selectedVehicle.Id,
                Brand = selectedVehicle.Brand,
                Model = selectedVehicle.Model,
                CategoryId=selectedVehicle.CategoryId,
                Year = selectedVehicle.Year,
                ImgUrl = selectedVehicle.ImgUrl,
            };
            return result;
        }
    }
}
