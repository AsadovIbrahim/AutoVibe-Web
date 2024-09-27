using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Domain.DTO_s
{
    public class UpdateVehicleDTO
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string? ImgUrl { get; set; }
    }
}
