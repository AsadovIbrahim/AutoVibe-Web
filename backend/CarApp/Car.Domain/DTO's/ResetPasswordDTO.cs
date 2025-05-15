using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Car.Domain.DTO_s
{
    public class ResetPasswordDTO
    {
        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
