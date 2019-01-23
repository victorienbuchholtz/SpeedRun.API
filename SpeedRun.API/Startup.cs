using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SpeedRun.API.Bootstrap;
using SpeedRun.Models.Models;
using SpeedRun.Services.Services;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

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
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
                    options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
                });

            services.AddDbContext<SpeedRunDbContext>(options => options.UseMySql(Configuration.GetConnectionString("SpeedRun")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<SpeedRunDbContext>()
                .AddDefaultTokenProviders();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = Configuration["JwtIssuer"],
                    ValidAudience = Configuration["JwtIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtKey"])),
                    ClockSkew = TimeSpan.FromMinutes(2)
                };
            });

            services.AddAuthorization(opts =>
            {
                opts.AddPolicy("User", p =>
                {
                    p.RequireClaim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "User");
                });
                opts.AddPolicy("Admin", p =>
                {
                    p.RequireClaim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Admin");
                });
            });

            DependencyInjector.InjectRepositories(services);
            DependencyInjector.InjectServices(services);

            services.AddHttpClient<IgdbService>(client =>
            {
                client.BaseAddress = new Uri("https://api-v3.igdb.com");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("user-key", Configuration["Igdb:UserKey"]);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, SpeedRunDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            context.Database.EnsureCreated();
        }
    }
}