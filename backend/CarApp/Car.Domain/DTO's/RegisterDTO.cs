using System.ComponentModel.DataAnnotations;

namespace Car.Domain.DTO_s
{
    public class RegisterDTO
    {
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]

        public string ConfirmPassword { get; set; }
        public string? ProfilePhoto { get; set; }
    }
}
