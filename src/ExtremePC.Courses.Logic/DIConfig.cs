using ExtremePC.Courses.Dal;
using ExtremePC.Courses.Definition.Services;
using ExtremePC.Courses.Logic.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExtremePC.Courses.Logic
{
    public static class DIConfig
    {
        public static void ConfigureLogicServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureDalServices(configuration);
            services.AddScoped<ISignupService, SignupService>();
        }
    }
}
