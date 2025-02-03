using Car.Application.Repositories;
using Car.Application.Services;
using Car.Domain.DTO_s;
using Car.Domain.Entities.Concretes;
using Car.Domain.Helpers;
using Car.Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Car.Persistance.Services
{
    public class AuthService : IAuthService
    {
        public HttpResponse Response { get; set; }
        private readonly IEmailService _emailService;
        private readonly ITokenService _tokenService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IReadUserRepository _readUserRepository;
        private readonly IWriteUserRepository _writeUserRepository;
        private readonly IReadUserTokenRepository _readUserTokenRepository;
        private readonly IWriteUserTokenRepository _writeUserTokenRepository;

        // Constructor

        public AuthService(
            UserManager<User> userManager, SignInManager<User> signInManager,
            IReadUserRepository readUserRepository, IWriteUserRepository writeUserRepository, ITokenService tokenService,
            IEmailService emailService, IReadUserTokenRepository readUserTokenRepository, IWriteUserTokenRepository writeUserTokenRepository)
        {

            _userManager = userManager;
            _tokenService = tokenService;
            _emailService = emailService;
            _signInManager = signInManager;
            _readUserRepository = readUserRepository;
            _writeUserRepository = writeUserRepository;
            _readUserTokenRepository = readUserTokenRepository;
            _writeUserTokenRepository = writeUserTokenRepository;
        }


        // Methods

        public async Task RefreshLogin(string refreshToken)
        {
            var user = await _readUserTokenRepository.GetUserByRefreshToken(refreshToken);
            if (user != null) await _signInManager.RefreshSignInAsync(user);
        }

        public async Task<LoginVM> Login(LoginDTO loginDTO, HttpResponse response)
        {

            var error = "";
            if (Response == null) Response = response;

            var user = await _userManager.FindByNameAsync(loginDTO.Username);

            if (user is null)
                error = "Username is wrong";
            else if (!user.EmailConfirmed)
                error = "Email not confirmed";

            var roles = (await _userManager.GetRolesAsync(user)).ToList();
            var result = await _signInManager.PasswordSignInAsync(user, loginDTO.Password, false, false);
            var accesstoken = await _tokenService.CreateAccessToken(user);
            var refreshtoken = _tokenService.CreateRefreshToken();

            await SetRefreshToken(user, refreshtoken);
            var loginVM = new LoginVM()
            {
                Roles = roles,
                AccessToken = accesstoken,
                ProfilePhoto = user.ProfilePhoto,
                Error = error.Length != 0 ? error : null
            };

            if (result.Succeeded)
                return loginVM;
            else
            {
                loginVM.Error = "Password is wrong.";
                return loginVM;
            }
        }

        public async Task<int> Register(RegisterDTO registerDTO, HttpResponse response)
        {

            if (Response == null) Response = response;

            var user = await _readUserRepository.GetUserByUserName(registerDTO.Username);
            if (user is not null)
                return 409;

            user = await _readUserRepository.GetUserByEmail(registerDTO.Email);
            if (user is not null)
                return 409;

            if (registerDTO.Password != registerDTO.ConfirmPassword) return -1;

            var newUser = await CreateNewUser(registerDTO);
            return newUser;
        }

        public async Task SetRefreshToken(User user, TokenCredentials refreshToken)
        {

            var cookieOptions = new CookieOptions()
            {
                HttpOnly = true,
                Expires = refreshToken.ExpireTime
            };

            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);

            var tokenstodelete = user.UserTokens.Where(p => p.Name == "RefreshToken").Where(p => p.IsDeleted == false);
            foreach (var token in tokenstodelete)
                token.IsDeleted = true;

            var refreshUserToken = new UserToken()
            {
                UserId = user.Id,
                Name = "RefreshToken",
                Token = refreshToken.Token,
                ExpireTime = refreshToken.ExpireTime.AddHours(4)
            };
            await _writeUserTokenRepository.AddAsync(refreshUserToken);
        }

        public async Task<TokenCredentials?> RefreshToken(HttpResponse response, HttpRequest Request)
        {

            if (Response == null) Response = response;

            var refreshToken = Request.Cookies["refreshToken"];
            if (string.IsNullOrEmpty(refreshToken))
                return null;

            var user = await _readUserTokenRepository.GetUserByRefreshToken(refreshToken);
            if (user is null)
                return null;


            var accessToken = await _tokenService.CreateAccessToken(user);
            var refreshTokenObj = _tokenService.CreateRefreshToken();

            await _writeUserRepository.UpdateAsync(user);
            await SetRefreshToken(user, refreshTokenObj);

            return accessToken;
        }

        private async Task<int> CreateNewUser(RegisterDTO registerDTO)
        {

            var newUser = new User();
            if (registerDTO.ProfilePhoto is null)
            {
                newUser = new User()
                {
                    FirstName = registerDTO.Firstname,
                    LastName = registerDTO.Lastname,
                    UserName = registerDTO.Username,
                    Email = registerDTO.Email
                };
            }
            else
            {
                newUser = new User()
                {
                    FirstName = registerDTO.Firstname,
                    LastName = registerDTO.Lastname,
                    UserName = registerDTO.Username,
                    Email = registerDTO.Email,
                    ProfilePhoto = registerDTO.ProfilePhoto
                };
            }

            var registerResult = await _userManager.CreateAsync(newUser, registerDTO.Password);

            if (registerResult.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(newUser.UserName);
                await _userManager.AddToRoleAsync(user!, "User");

                await SendConfirmEmail(registerDTO, newUser);

                return 200;
            }
            else return 400;
        }

        private async Task SendConfirmEmail(RegisterDTO registerDTO, User newUser)
        {

            var confirmEmailToken = _tokenService.CreateConfirmEmailToken();
            var actionUrl = $@"https://localhost:8000/api/Auth/ConfirmEmail?token={Uri.EscapeDataString(confirmEmailToken.Token)}";
            var result = await _emailService.SendMailAsync(registerDTO.Email, "Confirm Your Email", $"Reset your password by <a href='{actionUrl}'>clicking here</a>.", true);

            var userConfirmEmailToken = new UserToken()
            {
                UserId = newUser.Id,
                Name = "ConfirmEmailToken",
                Token = confirmEmailToken.Token,
                ExpireTime = confirmEmailToken.ExpireTime,
            };
            await _writeUserTokenRepository.AddAsync(userConfirmEmailToken);
        }

        public async Task<int> ConfirmEmail(string token)
        {

            var user = await _readUserTokenRepository.GetUserByConfirmEmailToken(token);
            if (user is null)
                return 404; 

            var confirmEmailToken = await _readUserTokenRepository.GetConfirmEmailToken(token);
            if (confirmEmailToken.ExpireTime < DateTime.UtcNow)
            {
                confirmEmailToken.IsDeleted = true;
                return 405;
            }

            confirmEmailToken.IsDeleted = true;
            await _writeUserTokenRepository.UpdateAsync(confirmEmailToken);

            user.EmailConfirmed = true;
            await _writeUserRepository.UpdateAsync(user);

            return 200;
        }

        public async Task<int> ForgotPassword(ForgotPasswordDTO forgotPasswordDTO)
        {

            var user = await _readUserRepository.GetUserByEmail(forgotPasswordDTO.Email);
            if (user is null)
                return 404; // BadRequest("User not found");

            var tokenstodelete = user.UserTokens!.Where(p => p.Name == "RepasswordToken").Where(p => p.IsDeleted == false);
            foreach (var token in tokenstodelete)
                token.IsDeleted = true;

            var forgotPasswordToken = await _tokenService.CreateRepasswordToken(user);
            var actionUrl = $@"http://localhost:8000/resetpassword?token={forgotPasswordToken.Token}";
            var result = await _emailService.SendMailAsync(forgotPasswordDTO.Email, "Reset Your Password", $"Reset your password by <a href='{actionUrl}'>clicking here</a>.", true);

            var userForgotPasswordToken = new UserToken()
            {
                UserId = user.Id,
                Name = "RepasswordToken",
                Token = forgotPasswordToken.Token,
                ExpireTime = forgotPasswordToken.ExpireTime,
            };
            await _writeUserTokenRepository.AddAsync(userForgotPasswordToken);

            return 200;
        }

        public async Task<int> ResetPassword(string token, ResetPasswordDTO resetPasswordDTO)
        {

            var user = await _readUserTokenRepository.GetUserByRePasswordToken(token);
            if (user is null)
                return 404; 

            var rePasswordToken = await _readUserTokenRepository.GetResetPasswordToken(token);
            if (rePasswordToken.ExpireTime < DateTime.UtcNow)
                return 405; 

            var result = await _userManager.ResetPasswordAsync(user, token, resetPasswordDTO.Password);
            if (result.Succeeded)
            {
                rePasswordToken.IsDeleted = true;
                await _writeUserRepository.UpdateAsync(user);
                await _writeUserRepository.SaveChangesAsync();
                await _writeUserTokenRepository.UpdateAsync(rePasswordToken);
                return 200;
            }
            return 400;
        }
    }
}
