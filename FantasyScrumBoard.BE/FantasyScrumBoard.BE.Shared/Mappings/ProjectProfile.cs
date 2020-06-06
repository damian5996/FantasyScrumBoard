using AutoMapper;
using FantasyScrumBoard.BE.Shared.BindingModels;
using FantasyScrumBoard.BE.Shared.Dto;
using FantasyScrumBoard.BE.Shared.Models;

namespace FantasyScrumBoard.BE.Shared.Mappings
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<ProjectAddBindingModel, ProjectDto>();
            CreateMap<ProjectDto, Project>()
                .ForMember(dest => dest.UserProjects, opt => opt.Ignore())
                .ForMember(dest => dest.Sprints, opt => opt.Ignore())
                .ForMember(dest => dest.WorkItems, opt => opt.Ignore());
        }
    }
}
