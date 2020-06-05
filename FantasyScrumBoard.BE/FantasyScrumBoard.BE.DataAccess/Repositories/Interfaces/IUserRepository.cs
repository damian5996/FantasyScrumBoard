using FantasyScrumBoard.BE.Shared.Dto;
using System.Threading.Tasks;

namespace FantasyScrumBoard.BE.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDto> GetByEmailOrDefaultAsync(string email);
    }
}
