using Car.Domain.Entities.Commons;

namespace Car.Domain.Entities.Concretes
{
    public class UserToken:BaseEntity
    {
        public string Name { get; set; }
        public string Token { get; set; }
        public DateTime ExpireTime { get; set; }
        public string UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
