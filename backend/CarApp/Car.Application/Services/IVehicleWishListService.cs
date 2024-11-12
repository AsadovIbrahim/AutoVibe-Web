using Car.Domain.DTO_s;

namespace Car.Application.Services
{
    public interface IVehicleWishListService
    {
        Task RemoveVehicleToWishListAsync(string userId, string vehicleId);
        Task<ICollection<GetVehicleDTO>> GetUserWishListAsync(string userId);
        Task<GetVehicleDTO> AddVehicleToWishListAsync(string userId, string vehicleId);

    }
}
