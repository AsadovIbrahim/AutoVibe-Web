using System.ComponentModel.DataAnnotations;

namespace Car.Domain.DTO_s
{
    public class ResetPasswordDTO
    {
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
