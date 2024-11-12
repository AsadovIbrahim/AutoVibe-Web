using Car.Domain.Entities.Concretes;
using Car.Application.Repositories.Common;

namespace Car.Application.Repositories.CarWishlist
{
    public interface IWriteVehicleWishListRepository:IWriteGenericRepository<UserWishList>
    {
        Task AddVehicleToUserWishListAsync(string userId, string vehicleId);
        Task RemoveVehicleToUserWishListAsync(string userId, string vehicleId);
    }
}
