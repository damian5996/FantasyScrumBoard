using AutoMapper;
using FantasyScrumBoard.BE.DataAccess.Connection;
using FantasyScrumBoard.BE.DataAccess.Repositories.Interfaces;
using FantasyScrumBoard.BE.Shared.Dto;
using FantasyScrumBoard.BE.Shared.Dto.Facebook;
using FantasyScrumBoard.BE.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
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
            var user = await _db.User.FirstOrDefaultAsync(user => user.Email == email);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<int> InsertAsync(FacebookUserDto facebookUserDto)
        {
            var user = _mapper.Map<User>(facebookUserDto);
            user.CreatedAt = DateTime.UtcNow;
            await _db.User.AddAsync(user);

            return await _db.SaveChangesAsync();
        }
    }
}
