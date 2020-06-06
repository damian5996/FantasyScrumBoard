using AutoMapper;
using FantasyScrumBoard.BE.Shared.BindingModels;
using FantasyScrumBoard.BE.Shared.Dto;
using FantasyScrumBoard.BE.Shared.Models;
using FantasyScrumBoard.BE.Shared.ViewModels;

namespace FantasyScrumBoard.BE.Shared.Mappings
{
    public class WorkItemProfile : Profile
    {
        public WorkItemProfile()
        {
            CreateMap<WorkItem, WorkItemDto>();
            CreateMap<WorkItemAddBindingModel, WorkItemDto>()
                .ForMember(dest => dest.Comments, opt => opt.Ignore())
                .ForMember(dest => dest.AssignedUser, opt => opt.Ignore());

            CreateMap<WorkItemDto, WorkItem>()
                .ForMember(dest => dest.Comments, opt => opt.Ignore())
                .ForMember(dest => dest.Sprint, opt => opt.Ignore())
                .ForMember(dest => dest.Project, opt => opt.Ignore())
                .ForMember(dest => dest.AssignedUser, opt => opt.Ignore());

            CreateMap<WorkItemDto, WorkItemViewModel>();
        }
    }
}
