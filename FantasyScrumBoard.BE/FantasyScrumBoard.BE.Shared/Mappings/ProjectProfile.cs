using AutoMapper;
using FantasyScrumBoard.BE.Shared.BindingModels;
using FantasyScrumBoard.BE.Shared.Dto;
using FantasyScrumBoard.BE.Shared.Models;
using FantasyScrumBoard.BE.Shared.ViewModels;

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

            CreateMap<Project, ProjectDto>()
                .ForMember(dest => dest.ProjectMembers, opt => opt.MapFrom(src => src.UserProjects));

            CreateMap<ProjectDto, ProjectViewModel>();

            CreateMap<ProjectDto, ProjectDetailsViewModel>()
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.ProjectMembers));

            CreateMap<long, ProjectDto>()
                .ConstructUsing(projectId => new ProjectDto {Id = projectId});
        }
    }
}
