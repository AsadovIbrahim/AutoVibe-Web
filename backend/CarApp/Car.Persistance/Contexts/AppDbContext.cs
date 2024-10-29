using Car.Domain.Entities.Concretes;
using Car.Persistance.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Car.Persistance.Contexts
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new VehicleConfiguration());
            base.OnModelCreating(builder);
        }

        public virtual DbSet<Vehicle>Vehicles { get; set; }
        public virtual DbSet<UserToken> UserTokens { get; set; }
    }
}
