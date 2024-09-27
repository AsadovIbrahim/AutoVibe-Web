using Car.Domain.Entities.Abstracts;
using Microsoft.AspNetCore.Identity;

namespace Car.Domain.Entities.Concretes
{
    public class User : IdentityUser, IBaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public string ProfilePhoto { get; set; } = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b5/Windows_10_Default_Profile_Picture.svg/1024px-Windows_10_Default_Profile_Picture.svg.png";

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public virtual ICollection<UserToken>? UserTokens { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }=new List<Vehicle>();

    }
}
