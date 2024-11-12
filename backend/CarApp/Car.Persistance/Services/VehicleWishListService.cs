using Car.Domain.DTO_s;
using Car.Application.Services;
using Car.Application.Repositories.Car;
using Car.Application.Repositories.CarWishlist;

namespace Car.Persistance.Services
{
    public class VehicleWishListService : IVehicleWishListService
    {
        private readonly IReadVehicleRepository _readVehicleRepository;
        private readonly IWriteVehicleWishListRepository _writeVehicleWishListRepository;
        private readonly IReadVehicleWishListRepository _readVehicleWishListRepository;
        public VehicleWishListService(IWriteVehicleWishListRepository writeVehicleWishListRepository,
            IReadVehicleWishListRepository readVehicleWishListRepository,
            IReadVehicleRepository readVehicleRepository)
        {
            _writeVehicleWishListRepository = writeVehicleWishListRepository;
            _readVehicleWishListRepository = readVehicleWishListRepository;
            _readVehicleRepository = readVehicleRepository;
        }
        public async Task<GetVehicleDTO> AddVehicleToWishListAsync(string userId, string vehicleId)
        {
            if (await _readVehicleWishListRepository.IsVehicleInUserWishListAsync(userId, vehicleId))
                throw new InvalidOperationException("Vehicle already in wishlist.");

            await _writeVehicleWishListRepository.AddVehicleToUserWishListAsync(userId, vehicleId);

            var vehicle = await _readVehicleRepository.GetByIdAsync(vehicleId);
            return new GetVehicleDTO
            {
                Id = vehicle.Id,
                Brand = vehicle.Brand,
                Model = vehicle.Model,
                Year = vehicle.Year,
                FuelType = vehicle.FuelType.ToString(),
                VehicleType = vehicle.VehicleType.ToString(),
                ImgUrl = vehicle.ImgUrl
            };
        }

        public async Task<ICollection<GetVehicleDTO>> GetUserWishListAsync(string userId)
        {
            var wishListItems = await _readVehicleWishListRepository.GetUserWishListAsync(userId);
            var vehicleDTOs = wishListItems.Select(wishListItem => new GetVehicleDTO
            {
                Id = wishListItem.Id,
                Brand = wishListItem.Brand,
                Model = wishListItem.Model,
                Year = wishListItem.Year,
                FuelType = wishListItem.FuelType.ToString(),
                VehicleType = wishListItem.VehicleType.ToString(),
                ImgUrl = wishListItem.ImgUrl
            }).ToList();

            return vehicleDTOs;
        }

        public async Task RemoveVehicleToWishListAsync(string userId, string vehicleId)
        {
            if (!await _readVehicleWishListRepository.IsVehicleInUserWishListAsync(userId, vehicleId))
                throw new InvalidOperationException("Vehicle not found in wishlist.");

            await _writeVehicleWishListRepository.RemoveVehicleToUserWishListAsync(userId, vehicleId);
        }
    }
}
