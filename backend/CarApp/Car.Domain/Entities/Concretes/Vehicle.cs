using Car.Domain.Entities.Abstracts;
using Car.Domain.Enums.FuelTypes;
using Car.Domain.Enums.VehicleType;

namespace Car.Domain.Entities.Concretes
{
    public class Vehicle:IBaseEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public FuelType FuelType { get; set; }
        public VehicleType VehicleType { get; set; }
        public string ?ImgUrl { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        //Foreign Key

        public string? UserId { get; set; }
        public virtual User? User { get; set; }

        //Navigation Properties

        public virtual ICollection<UserWishList> WishLists { get; set; } = new List<UserWishList>();
    }
}
