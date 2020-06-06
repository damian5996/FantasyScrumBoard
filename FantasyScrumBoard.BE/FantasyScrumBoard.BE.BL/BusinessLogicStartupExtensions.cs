using FantasyScrumBoard.BE.BL.Services;
using FantasyScrumBoard.BE.BL.Services.Interfaces;
using FantasyScrumBoard.BE.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FantasyScrumBoard.BE.BL
{
    public static class BusinessLogicStartupExtensions
    {
        public static IServiceCollection BusinessLogicConfigureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            return services
                .AddBusinessLogicDependencies()
                .DataAccessConfigureServices(configuration);
        }

        public static IServiceCollection AddBusinessLogicDependencies(this IServiceCollection services)
        {
            return services
                .AddScoped<IJwtService, JwtService>();
        }

        public static IApplicationBuilder BusinessLogicConfigure(this IApplicationBuilder app)
        {
            return app
                .DataAccessConfigure();
        }
    }
}
