using Microsoft.Extensions.DependencyInjection;
using SpeedRun.Models;
using SpeedRun.Models.Models;
using SpeedRun.Repository.Repositories;
using SpeedRun.RepositoryGeneric.Interface;
using SpeedRun.Services.Interfaces;
using SpeedRun.Services.Services;

namespace SpeedRun.API.Bootstrap
{
    public class DependencyInjector
    {
        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddScoped<IRepositoryGeneric<Value>, SpeedRunRepository<Value>>();
            services.AddScoped<IRepositoryGeneric<User>, SpeedRunRepository<User>>();
            services.AddScoped<IRepositoryGeneric<Product>, SpeedRunRepository<Product>>();
            services.AddScoped<IRepositoryGeneric<Order>, SpeedRunRepository<Order>>();
            services.AddScoped<IRepositoryGeneric<DeliveryAddress>, SpeedRunRepository<DeliveryAddress>>();
        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddScoped<IValueService, ValueService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IDeliveryAddressService, DeliveryAddressService>();
        }
    }
}
