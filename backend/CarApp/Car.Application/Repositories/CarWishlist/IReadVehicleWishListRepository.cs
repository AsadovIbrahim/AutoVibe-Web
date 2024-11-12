using Car.Domain.Entities.Concretes;
using Car.Application.Repositories.Common;

namespace Car.Application.Repositories.CarWishlist
{
    public interface IReadVehicleWishListRepository:IReadGenericRepository<UserWishList>
    {
        Task<ICollection<Vehicle>> GetUserWishListAsync(string userId);
        Task<bool> IsVehicleInUserWishListAsync(string userId, string vehicleId);
    }
}
