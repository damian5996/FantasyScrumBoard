using AutoMapper;
using FantasyScrumBoard.BE.BL.Common;
using FantasyScrumBoard.BE.BL.Services.Interfaces;
using FantasyScrumBoard.BE.BL.User.Interfaces;
using FantasyScrumBoard.BE.BL.User.Internal;
using FantasyScrumBoard.BE.DataAccess;
using FantasyScrumBoard.BE.DataAccess.Repositories.Interfaces;
using FantasyScrumBoard.BE.Shared.BindingModels;
using FantasyScrumBoard.BE.Shared.Dto;
using FantasyScrumBoard.BE.Shared.Enums;
using FantasyScrumBoard.BE.Shared.Exceptions;
using FantasyScrumBoard.BE.Shared.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyScrumBoard.BE.BL.User
{
    internal class UserFacebookAuthenticationLogic : BaseBusinessLogic<FacebookLoginBindingModel, UserWithTokenDto, UserWithTokenViewModel>, IUserFacebookAuthenticationLogic
    {
        private readonly IFacebookApiRepository _facebookApiRepository;
        private readonly GetUserByEmail _getUserByEmail;
        private readonly IJwtService _jwtService;

        public UserFacebookAuthenticationLogic(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            ILogger<UserFacebookAuthenticationLogic> logger,
            IFacebookApiRepository facebookApiRepository,
            IJwtService jwtService) : base(unitOfWork, mapper, logger)
        {
            _facebookApiRepository = facebookApiRepository;
            _getUserByEmail = new GetUserByEmail(unitOfWork);
            _jwtService = jwtService;
        }

        protected override IEnumerable<IValidator<FacebookLoginBindingModel>> Validators =>
            Enumerable.Empty<IValidator<FacebookLoginBindingModel>>();
        protected override async Task<UserWithTokenDto> ExecutionAsync(FacebookLoginBindingModel parameter)
        {
            var isTokenValid = await _facebookApiRepository.ValidateTokenAsync(parameter.Token);

            if (!isTokenValid)
            {
                throw new BusinessLogicException("", ExceptionType.Unauthorized);
            }

            var facebookUserDto = await _facebookApiRepository.GetUserInfoAsync(parameter.Token);

            var userDto = await _getUserByEmail.ExecuteAsync(facebookUserDto.Email, false);
            //zle pobiera date 01.01.0001 ??
            if (userDto == null)
            {
                await UnitOfWork.User.InsertAsync(facebookUserDto);
                userDto = await _getUserByEmail.ExecuteAsync(facebookUserDto.Email, false);
            }

            var userWithTokenDto = Mapper.Map<UserWithTokenDto>(userDto);

            userWithTokenDto.JwtDto = _jwtService.GenerateToken(userDto);

            return userWithTokenDto;
        }
    }
}
