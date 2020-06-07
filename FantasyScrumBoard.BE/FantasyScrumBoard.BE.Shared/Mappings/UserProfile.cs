using AutoMapper;
using FantasyScrumBoard.BE.Shared.Dto;
using FantasyScrumBoard.BE.Shared.Dto.Facebook;
using FantasyScrumBoard.BE.Shared.Models;
using FantasyScrumBoard.BE.Shared.ViewModels;

namespace FantasyScrumBoard.BE.Shared.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserWithTokenDto, UserWithTokenViewModel>()
                .ForMember(dest => dest.ExpirationDate, opt => opt.MapFrom(src => src.JwtDto.ExpirationDate))
                .ForMember(dest => dest.Token, opt => opt.MapFrom(src => src.JwtDto.Token))
                .ForMember(dest => dest.RefreshToken, opt => opt.MapFrom(src => src.JwtDto.RefreshToken));
            CreateMap<UserDto, UserWithTokenDto>();
            CreateMap<FacebookUserDto, User>();
            CreateMap<User, UserDto>();

            CreateMap<UserProject, ProjectMemberDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.ProjectExp, opt => opt.MapFrom(src => src.Exp))
                .ForMember(dest => dest.ProjectLevel, opt => opt.MapFrom(src => src.Level))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.Nick, opt => opt.MapFrom(src => src.User.Nick));

            CreateMap<ProjectMemberDto, ProjectMemberViewModel>();
        }
    }
}
