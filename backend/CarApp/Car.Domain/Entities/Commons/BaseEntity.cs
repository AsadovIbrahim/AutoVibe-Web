using Car.Domain.Entities.Abstracts;

namespace Car.Domain.Entities.Commons
{
    public class BaseEntity : IBaseEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
