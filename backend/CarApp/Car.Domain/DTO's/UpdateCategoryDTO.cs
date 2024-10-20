namespace Car.Domain.DTO_s
{
    public class UpdateCategoryDTO
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
    }
}
