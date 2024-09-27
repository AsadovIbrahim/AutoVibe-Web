using Car.Domain.Helpers;

namespace Car.Domain.ViewModels
{
    public class LoginVM
    {
        public string? Error { get; set; }
        public string ProfilePhoto { get; set; }
        public List<string> Roles { get; set; }
        public TokenCredentials AccessToken { get; set; }
    }
}
