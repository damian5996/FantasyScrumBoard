using FantasyScrumBoard.BE.DataAccess.Connection;
using FantasyScrumBoard.BE.DataAccess.Repositories;
using FantasyScrumBoard.BE.DataAccess.Repositories.Interfaces;
using FantasyScrumBoard.BE.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
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
                .AddDataAccessDependencies(configuration);
        }
        public static IServiceCollection AddDataAccessDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddDbContext<FantasyScrumBoardDbContext>(options =>
                    options
                        .UseLazyLoadingProxies()
                        .UseSqlServer(configuration
                            .GetConnectionString(Constants.Database.DefaultConnectionString)))
                .AddScoped<IAchievementRepository, AchievementRepository>()
                .AddScoped<ICommentRepository, CommentRepository>()
                .AddScoped<INotificationRepository, NotificationRepository>()
                .AddScoped<IProjectRepository, ProjectRepository>()
                .AddScoped<ISprintRepository, SprintRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IFacebookApiRepository, FacebookApiRepository>()
                .AddScoped<IWorkItemRepository, WorkItemRepository>()
                .AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static IApplicationBuilder DataAccessConfigure(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();
            
            using var context = serviceScope.ServiceProvider.GetRequiredService<FantasyScrumBoardDbContext>();
            context.Database.Migrate();

            return app;
        }
    }
}
