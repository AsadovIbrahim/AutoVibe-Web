using Car.Domain.Entities.Abstracts;

namespace Car.Domain.Entities.Concretes
{
    public class UserWishList : IBaseEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string UserId { get; set; }
        public virtual User User { get; set; }

        public string VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public bool IsDeleted { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
