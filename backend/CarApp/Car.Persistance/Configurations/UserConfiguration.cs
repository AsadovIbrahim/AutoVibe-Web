using Car.Domain.Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Car.Persistance.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(p => p.Vehicles)
                .WithOne(x => x.User)
                .HasForeignKey(p=>p.UserId);

            builder.HasMany(p=>p.WishLists)
                .WithOne(x => x.User)
                .HasForeignKey(p=>p.UserId);
        }
    }
}
