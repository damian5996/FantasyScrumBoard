using FantasyScrumBoard.BE.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace FantasyScrumBoard.BE.DataAccess.Connection
{
    public class FantasyScrumBoardDbContext : DbContext
    {
        public FantasyScrumBoardDbContext(DbContextOptions options) : base(options) { }

        //public DbSet<Achievement> Achievement { get; set; }
        //public DbSet<Comment> Comment { get; set; }
        //public DbSet<Notification> Notification { get; set; }
        //public DbSet<Project> Project { get; set; }
        //public DbSet<Sprint> Sprint { get; set; }
        //public DbSet<User> User { get; set; }
        //public DbSet<UserAchievement> UserAchievement { get; set; }
        //public DbSet<UserProject> UserProject { get; set; }
        //public DbSet<WorkItem> WorkItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //here entity configuration

            base.OnModelCreating(modelBuilder);
        }
    }
}
