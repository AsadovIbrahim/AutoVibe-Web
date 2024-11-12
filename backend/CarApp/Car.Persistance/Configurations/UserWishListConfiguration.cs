using Microsoft.EntityFrameworkCore;
using Car.Domain.Entities.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Car.Persistance.Configurations
{
    public class UserWishListConfiguration : IEntityTypeConfiguration<UserWishList>
    {
        public void Configure(EntityTypeBuilder<UserWishList> builder)
        {
            builder.HasOne(p => p.User)
                .WithMany(w => w.WishLists)
                .HasForeignKey(u => u.UserId);

            builder.HasOne(v => v.Vehicle)
                .WithMany(w => w.WishLists)
                .HasForeignKey(v => v.VehicleId);
        }
    }
}
