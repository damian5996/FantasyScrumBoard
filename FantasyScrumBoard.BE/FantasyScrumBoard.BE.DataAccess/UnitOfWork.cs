using System.Threading.Tasks;
using FantasyScrumBoard.BE.DataAccess.Connection;
using FantasyScrumBoard.BE.DataAccess.Repositories.Interfaces;

namespace FantasyScrumBoard.BE.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FantasyScrumBoardDbContext _dbContext;

        public UnitOfWork(
            IAchievementRepository achievement, 
            ICommentRepository comment,
            INotificationRepository notification, 
            IProjectRepository project, 
            ISprintRepository sprint,
            IUserRepository user, 
            IWorkItemRepository workItem, 
            FantasyScrumBoardDbContext dbContext)
        {
            Achievement = achievement;
            Comment = comment;
            Notification = notification;
            Project = project;
            Sprint = sprint;
            User = user;
            WorkItem = workItem;
            _dbContext = dbContext;
        }

        public IAchievementRepository Achievement { get; }
        public ICommentRepository Comment { get; }
        public INotificationRepository Notification { get; }
        public IProjectRepository Project { get; }
        public ISprintRepository Sprint { get; }
        public IUserRepository User { get; }
        public IWorkItemRepository WorkItem { get; }
        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
