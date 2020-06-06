using FantasyScrumBoard.BE.Shared.Dto;
using FantasyScrumBoard.BE.Shared.Dto.Facebook;
using System.Threading.Tasks;

namespace FantasyScrumBoard.BE.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDto> GetByEmailOrDefaultAsync(string email);
        Task<int> InsertAsync(FacebookUserDto facebookUserDto);
    }
}
