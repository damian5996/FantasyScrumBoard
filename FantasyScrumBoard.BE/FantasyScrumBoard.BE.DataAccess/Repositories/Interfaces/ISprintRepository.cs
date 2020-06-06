using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FantasyScrumBoard.BE.Shared.Dto;

namespace FantasyScrumBoard.BE.DataAccess.Repositories.Interfaces
{
    public interface ISprintRepository
    {
        IQueryable<SprintDto> GetAll();
        Task<IEnumerable<SprintDto>> GetByProjectIdAsync(long projectId);
        Task<long> InsertAsync(SprintDto sprintDto);
        Task UpdateAsync(SprintDto sprintDto);
        Task<SprintDto> GetByIdAsync(long sprintId);
    }
}
