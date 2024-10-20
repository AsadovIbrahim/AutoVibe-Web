using Car.Domain.Entities.Abstracts;

namespace Car.Domain.Entities.Concretes
{
    public class Category : IBaseEntity
    {
        public string Id { get; set; } =Guid.NewGuid().ToString();
        public string Name { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedAt { get; set; }=DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public virtual ICollection<Vehicle>? Vehicles { get; set; } = new List<Vehicle>();
    }
}
