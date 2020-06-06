using System.Linq;
using System.Threading.Tasks;
using FantasyScrumBoard.BE.Shared.Dto;

namespace FantasyScrumBoard.BE.DataAccess.Repositories.Interfaces
{
    public interface IProjectRepository
    {
        IQueryable<ProjectDto> GetAll();
        Task<long> InsertAsync(ProjectDto projectDto);
        Task<ProjectDto> GetByIdAsync(long projectId);
    }
}
