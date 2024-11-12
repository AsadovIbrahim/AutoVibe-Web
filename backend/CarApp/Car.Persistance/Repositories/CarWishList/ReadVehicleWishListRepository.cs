using Car.Persistance.Contexts;
using Car.Domain.Entities.Concretes;
using Car.Persistance.Repositories.Common;
using Car.Application.Repositories.CarWishlist;
using Microsoft.EntityFrameworkCore;

namespace Car.Persistance.Repositories.CarWishList
{
    public class ReadVehicleWishListRepository : ReadGenericRepository<UserWishList>, IReadVehicleWishListRepository
    {
        public ReadVehicleWishListRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<ICollection<Vehicle>> GetUserWishListAsync(string userId)
        {
            return await _table.Where(p => p.UserId == userId)
                .Select(v => v.Vehicle)
                .ToListAsync();
        }

        public async Task<bool> IsVehicleInUserWishListAsync(string userId, string vehicleId)
        {
            return await _table.AnyAsync(p=>p.UserId==userId && p.VehicleId==vehicleId);
        }
    }
}
