using Car.Domain.DTO_s;
using Car.Domain.Entities.Concretes;
using Car.Domain.Helpers;
using Car.Domain.ViewModels;
using Microsoft.AspNetCore.Http;

namespace Car.Application.Services
{
    public interface IAuthService
    {
        Task<int> ConfirmEmail(string token);
        Task RefreshLogin(string refreshToken);
        Task<LoginVM> Login(LoginDTO loginDTO, HttpResponse response);
        Task<int> ForgotPassword(ForgotPasswordDTO forgotPasswordDTO);
        Task SetRefreshToken(User user, TokenCredentials refreshToken);
        Task<int> Register(RegisterDTO registerDTO, HttpResponse response);
        Task<int> ResetPassword(string token, ResetPasswordDTO resetPasswordDTO);
        Task<TokenCredentials?> RefreshToken(HttpResponse response, HttpRequest request);
    }
}
