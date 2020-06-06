using System.Reflection;
using AutoMapper;
using FantasyScrumBoard.BE.Shared.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FantasyScrumBoard.BE.Shared
{
    public static class SharedStartupExtensions
    {
        public static IServiceCollection SharedConfigureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            return services
                .AddSharedDependencies(configuration)
                .AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        public static IServiceCollection AddSharedDependencies(this IServiceCollection services,
            IConfiguration configuration)
        {
            return services
                .AddSingleton(configuration.GetSection(Constants.Constants.Configuration.JwtRoot).Get<JwtConfiguration>());
        }
    }
}
