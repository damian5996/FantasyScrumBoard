using AutoMapper;
using FantasyScrumBoard.BE.Shared.Dto;
using FantasyScrumBoard.BE.Shared.Dto.Facebook;
using FantasyScrumBoard.BE.Shared.Models;
using FantasyScrumBoard.BE.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyScrumBoard.BE.Shared.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserWithTokenDto, UserWithTokenViewModel>()
                .ForMember(x => x.ExpirationDate, opt => opt.MapFrom(x => x.JwtDto.ExpirationDate))
                .ForMember(x => x.Token, opt => opt.MapFrom(x => x.JwtDto.Token))
                .ForMember(x => x.RefreshToken, opt => opt.MapFrom(x => x.JwtDto.RefreshToken));
            CreateMap<UserDto, UserWithTokenDto>();
            CreateMap<FacebookUserDto, User>();
            CreateMap<User, UserDto>();
        }
    }
}
