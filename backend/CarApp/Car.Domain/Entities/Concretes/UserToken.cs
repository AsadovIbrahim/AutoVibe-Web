using Car.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
