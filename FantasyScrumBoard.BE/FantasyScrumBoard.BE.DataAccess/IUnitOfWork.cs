using System.Threading.Tasks;
using FantasyScrumBoard.BE.DataAccess.Repositories.Interfaces;

namespace FantasyScrumBoard.BE.DataAccess
{
    public interface IUnitOfWork
    {
        IAchievementRepository Achievement { get; }
        ICommentRepository Comment { get; }
        INotificationRepository Notification { get; }
        IProjectRepository Project { get; }
        ISprintRepository Sprint { get; }
        IUserRepository User { get; }
        IWorkItemRepository WorkItem { get; }

        Task SaveAsync();
    }
}
