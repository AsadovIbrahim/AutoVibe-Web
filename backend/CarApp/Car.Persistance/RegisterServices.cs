﻿using Car.Application.Repositories;
using Car.Application.Repositories.Car;
using Car.Application.Services;
using Car.Persistance.Contexts;
using Car.Persistance.Repositories;
using Car.Persistance.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
            services.AddScoped<ICategoryService, CategoryService>();


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
            services.AddScoped<IWriteCategoryRepository, WriteCategoryRepository>();
            services.AddScoped<IWriteUserTokenRepository, WriteUserTokenRepository>();

            //All Read Repositories
            services.AddScoped<IReadUserRepository, ReadUserRepository>();
            services.AddScoped<IReadVehicleRepository, ReadVehicleRepository>();
            services.AddScoped<IReadCategoryRepository, ReadCategoryRepository>();
            services.AddScoped<IReadUserTokenRepository, ReadUserTokenRepository>();
        }
    }
}
