using Car.Domain.Entities.Abstracts;

namespace Car.Domain.Entities.Concretes
{
    public class Vehicle:IBaseEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string ?ImgUrl { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        //Foreign Key

        public string? UserId { get; set; }
        public string CategoryId { get; set; }

        //Navigation Properties
        public virtual Category ?Category { get; set; }
        public virtual User? User { get; set; }
    }
}
