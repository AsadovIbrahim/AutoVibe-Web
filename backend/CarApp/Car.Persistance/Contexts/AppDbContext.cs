using Car.Domain.Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Car.Persistance.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Car.Persistance.Contexts
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new VehicleConfiguration());
            builder.ApplyConfiguration(new UserWishListConfiguration());
        }

        public virtual DbSet<Vehicle>Vehicles { get; set; }
        public virtual DbSet<UserToken> UserTokens { get; set; }
        public virtual DbSet<UserWishList>WishLists { get; set; }
    }
}
