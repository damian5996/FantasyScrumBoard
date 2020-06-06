using FantasyScrumBoard.BE.Shared.Dto.Facebook;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FantasyScrumBoard.BE.DataAccess.Repositories.Interfaces
{
    public interface IFacebookApiRepository
    {
        Task<bool> ValidateTokenAsync(string token);
        Task<FacebookUserDto> GetUserInfoAsync(string token);
    }
}
