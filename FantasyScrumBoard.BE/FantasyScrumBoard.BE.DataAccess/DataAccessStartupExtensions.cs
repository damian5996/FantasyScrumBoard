using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FantasyScrumBoard.BE.DataAccess
{
    public static class DataAccessStartupExtensions
    {
        public static IServiceCollection DataAccessConfigureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            return services
                .AddDataAccessDependencies();
        }
        public static IServiceCollection AddDataAccessDependencies(this IServiceCollection services)
        {
            return services
                .AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static IApplicationBuilder DataAccessConfigure(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
