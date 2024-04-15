using BLL;
using System.Security.Cryptography.X509Certificates;

namespace UI
{
    public static class ConfigureUI
    {
        public static void ConfigureUIService(this IServiceCollection services, string connString) 
        {
            services.ConfigureBLLServices(connString);
        }
    }
}
