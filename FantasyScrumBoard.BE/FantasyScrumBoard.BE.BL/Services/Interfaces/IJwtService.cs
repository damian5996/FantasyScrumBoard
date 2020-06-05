using System.Threading.Tasks;
using FantasyScrumBoard.BE.Shared.Dto;

namespace FantasyScrumBoard.BE.BL.Services.Interfaces
{
    public interface IJwtService
    {
        JwtDto GenerateToken(UserDto user);
        Task<JwtDto> RefreshToken(string refreshToken);
    }
}
