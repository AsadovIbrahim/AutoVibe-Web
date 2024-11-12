using Car.Persistance.Services;
using Car.Application.Services;
using Car.Persistance.Contexts;
using Car.Persistance.Repositories;
using Car.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using Car.Application.Repositories.Car;
using Microsoft.Extensions.Configuration;
using Car.Persistance.Repositories.CarWishList;
using Car.Application.Repositories.CarWishlist;
using Microsoft.Extensions.DependencyInjection;

namespace Car.Persistance
{
    public static class RegisterServices
    {
        public static void AddPersistanceRegister(this IServiceCollection services)
        {
            //Services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IVehicleWishListService, VehicleWishListService>();


            services.AddDbContext<AppDbContext>(options =>
            {
                ConfigurationBuilder configurationBuilder = new();
                var builder = configurationBuilder.AddJsonFile("appsettings.json").Build();

                options.UseLazyLoadingProxies()
                       .UseSqlServer(builder.GetConnectionString("default"));
            });

            //Register All Repositories

            //All Write Repositories
            services.AddScoped<IWriteUserRepository, WriteUserRepository>();
            services.AddScoped<IWriteVehicleRepository, WriteVehicleRepository>();
            services.AddScoped<IWriteUserTokenRepository, WriteUserTokenRepository>();
            services.AddScoped<IWriteVehicleWishListRepository, WriteVehicleWishListRepository>();

            //All Read Repositories
            services.AddScoped<IReadUserRepository, ReadUserRepository>();
            services.AddScoped<IReadVehicleRepository, ReadVehicleRepository>();
            services.AddScoped<IReadUserTokenRepository, ReadUserTokenRepository>();
            services.AddScoped<IReadVehicleWishListRepository, ReadVehicleWishListRepository>();
        }
    }
}
