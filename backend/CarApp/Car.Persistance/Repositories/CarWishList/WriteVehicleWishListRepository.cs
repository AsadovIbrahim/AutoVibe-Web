using Car.Persistance.Contexts;
using Car.Domain.Entities.Concretes;
using Car.Persistance.Repositories.Common;
using Car.Application.Repositories.CarWishlist;
using Microsoft.EntityFrameworkCore;

namespace Car.Persistance.Repositories.CarWishList
{
    public class WriteVehicleWishListRepository : WriteGenericRepository<UserWishList>, IWriteVehicleWishListRepository
    {
        public WriteVehicleWishListRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddVehicleToUserWishListAsync(string userId, string vehicleId)
        {
            var wishListItem = new UserWishList
            {
                UserId = userId,
                VehicleId = vehicleId
            };
            await _table.AddAsync(wishListItem);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveVehicleToUserWishListAsync(string userId, string vehicleId)
        {
            var wishListItem=await _table.FirstOrDefaultAsync(p=>p.UserId==userId && p.VehicleId==vehicleId);
            if (wishListItem != null)
            {
                _table.Remove(wishListItem);
                await _context.SaveChangesAsync();

            }
        }
    }
}
