using FantasyScrumBoard.BE.DataAccess;
using FantasyScrumBoard.BE.Shared;
using FantasyScrumBoard.BE.Shared.Dto;
using FantasyScrumBoard.BE.Shared.Enums;
using FantasyScrumBoard.BE.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FantasyScrumBoard.BE.BL.User.Internal
{
    public class GetUserByEmail
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserByEmail(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDto> ExecuteAsync(string email, bool throwIfNull = true)
        {
            var userDto = await _unitOfWork.User.GetByEmailOrDefaultAsync(email);

            if (userDto == null && throwIfNull)
            {
                throw new BusinessLogicException(
                    string.Format(Constants.ErrorMessage.NotFoundTemplate, nameof(_unitOfWork.User), email),
                    ExceptionType.NotFound);
            }

            return userDto;
        }
    }
}
