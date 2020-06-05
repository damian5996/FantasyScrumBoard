using AutoMapper;
using FantasyScrumBoard.BE.DataAccess.Connection;
using FantasyScrumBoard.BE.DataAccess.Repositories.Interfaces;
using FantasyScrumBoard.BE.Shared.Dto;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FantasyScrumBoard.BE.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FantasyScrumBoardDbContext _db;
        private readonly IMapper _mapper;

        public UserRepository(FantasyScrumBoardDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<UserDto> GetByEmailOrDefaultAsync(string email)
        {
            return _mapper.Map<UserDto>(await _db.User.FirstOrDefaultAsync(user => user.Email == email));
        }
    }
}
