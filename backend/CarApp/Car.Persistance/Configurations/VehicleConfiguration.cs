using Car.Domain.Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Car.Persistance.Configurations
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasOne(p => p.User)
                .WithMany(v => v.Vehicles)
                .HasForeignKey(p => p.UserId);

            builder.HasOne(c=>c.Category)
                .WithMany(v=>v.Vehicles)
                .HasForeignKey(c => c.CategoryId);
        }
    }
}
