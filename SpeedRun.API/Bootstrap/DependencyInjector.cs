using Microsoft.Extensions.DependencyInjection;
using SpeedRun.Models;
using SpeedRun.Repository.Repostories;
using SpeedRun.RepositoryGeneric.Interface;
using SpeedRun.Services;
using SpeedRun.Services.Interfaces;

namespace SpeedRun.API.Bootstrap
{
    public class DependencyInjector
    {
        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddScoped<IRepositoryGeneric<Value>, SpeedRunRepository<Value>>();
        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddScoped<IValueService, ValueService>();
        }
    }
}
