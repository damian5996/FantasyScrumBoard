using AutoMapper;
using FantasyScrumBoard.BE.Shared.BindingModels;
using FantasyScrumBoard.BE.Shared.Dto;
using FantasyScrumBoard.BE.Shared.Models;
using FantasyScrumBoard.BE.Shared.ViewModels;

namespace FantasyScrumBoard.BE.Shared.Mappings
{
    public class SprintProfile : Profile
    {
        public SprintProfile()
        {
            CreateMap<SprintAddBindingModel, SprintDto>();
            CreateMap<SprintDto, Sprint>()
                .ForMember(dest => dest.Project, opt => opt.Ignore())
                .ForMember(dest => dest.Mvp, opt => opt.Ignore())
                .ForMember(dest => dest.WorkItems, opt => opt.Ignore());
            CreateMap<Sprint, SprintDto>();
            CreateMap<SprintDto, SprintViewModel>();
        }
    }
}
