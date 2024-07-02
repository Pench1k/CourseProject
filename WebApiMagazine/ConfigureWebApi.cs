using BLL;
using DAL.DbContext;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;

namespace WebApiMagazine
{
    public static class ConfigureWebApi
    {
        public static void ConfigureWebApiServices(this IServiceCollection services, string connString) 
        {
            services.ConfigureBLLServices(connString);

            services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            services.AddScoped<SignInManager<User>>();
        }
    }
}
