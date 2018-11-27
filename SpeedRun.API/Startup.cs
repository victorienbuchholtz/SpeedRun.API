using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpeedRun.API.Bootstrap;
using SpeedRun.Models.Models;

namespace SpeedRun.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<SpeedRunDbContext>(options => options.UseMySql(Configuration.GetConnectionString("SpeedRun")));

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<SpeedRunDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

            DependencyInjector.InjectRepositories(services);
            DependencyInjector.InjectServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(
                options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
            );


            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
