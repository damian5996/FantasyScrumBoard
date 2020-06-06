using System.Threading.Tasks;
using FantasyScrumBoard.BE.Shared.Dto;

namespace FantasyScrumBoard.BE.DataAccess.Repositories.Interfaces
{
    public interface IWorkItemRepository
    {
        Task<long> InsertAsync(WorkItemDto workItemDto);
        Task<WorkItemDto> GetByIdAsync(long id);
    }
}
