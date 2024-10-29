namespace Car.Domain.DTO_s
{
    public class GetVehicleDTO
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Brand { get; set; }
        public string Model { get; set; }
        public string FuelType { get; set; }  
        public string VehicleType { get; set; }  
        public string Year { get; set; }
        public string? ImgUrl { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
