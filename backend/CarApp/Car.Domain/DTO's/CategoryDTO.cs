namespace Car.Domain.DTO_s
{
    public class CategoryDTO
    {
        public string Id { get; set; }=Guid.NewGuid().ToString();
        public string Name { get; set; }
    }
}
