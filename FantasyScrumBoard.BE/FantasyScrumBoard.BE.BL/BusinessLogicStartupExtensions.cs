using FantasyScrumBoard.BE.BL.Project;
using FantasyScrumBoard.BE.BL.Project.Interfaces;
using FantasyScrumBoard.BE.BL.Services;
using FantasyScrumBoard.BE.BL.Services.Interfaces;
using FantasyScrumBoard.BE.BL.Sprint;
using FantasyScrumBoard.BE.BL.Sprint.Interfaces;
using FantasyScrumBoard.BE.BL.User;
using FantasyScrumBoard.BE.BL.User.Interfaces;
using FantasyScrumBoard.BE.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
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
                .AddTransient<IHttpContextAccessor, HttpContextAccessor>()
                .AddScoped<IJwtService, JwtService>()
                .AddScoped<ICurrentUserService, CurrentUserService>()
                .AddScoped<IProjectAddBusinessLogic, ProjectAddBusinessLogic>()
                .AddScoped<IUserFacebookAuthenticationLogic, UserFacebookAuthenticationLogic>()
                .AddScoped<ISprintAddBusinessLogic, SprintAddBusinessLogic>();
        }

        public static IApplicationBuilder BusinessLogicConfigure(this IApplicationBuilder app)
        {
            return app
                .DataAccessConfigure();
        }
    }
}
