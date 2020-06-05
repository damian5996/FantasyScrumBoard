using System.Reflection;
using AutoMapper;
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
                .AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
