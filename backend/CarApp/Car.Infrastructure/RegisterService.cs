using System.Text;
using Car.Application.Services;
using Car.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Car.Infrastructure
{
    public static class RegisterService
    {
        public static void AddInfrastructureRegister(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IEmailService, EmailService>();
            builder.Services.AddScoped<ITokenService, TokenService>();

            // Add Auth JWT

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        LifetimeValidator = (before, expires, token, param) => expires > DateTime.UtcNow,
                        ValidIssuer = builder.Configuration["JWT:Issuer"],
                        ValidAudience = builder.Configuration["JWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecretKey"]!))
                    };
                }).AddCookie("Cookies", options => {
                    options.ExpireTimeSpan = TimeSpan.FromDays(30);
                });
        }
    }
}
