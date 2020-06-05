using FantasyScrumBoard.BE.Shared.Models;
using FantasyScrumBoard.BE.Shared.Models.EntityConfig;
using Microsoft.EntityFrameworkCore;

namespace FantasyScrumBoard.BE.DataAccess.Connection
{
    public class FantasyScrumBoardDbContext : DbContext
    {
        public FantasyScrumBoardDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Achievement> Achievement { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Sprint> Sprint { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserAchievement> UserAchievement { get; set; }
        public DbSet<UserProject> UserProject { get; set; }
        public DbSet<WorkItem> WorkItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AchievementEntityConfig());
            modelBuilder.ApplyConfiguration(new CommentEntityConfig());
            modelBuilder.ApplyConfiguration(new NotificationEntityConfig());
            modelBuilder.ApplyConfiguration(new ProjectEntityConfig());
            modelBuilder.ApplyConfiguration(new SprintEntityConfig());
            modelBuilder.ApplyConfiguration(new UserAchievementEntityConfig());
            modelBuilder.ApplyConfiguration(new UserEntityConfig());
            modelBuilder.ApplyConfiguration(new UserProjectEntityConfig());
            modelBuilder.ApplyConfiguration(new WorkItemEntityConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
