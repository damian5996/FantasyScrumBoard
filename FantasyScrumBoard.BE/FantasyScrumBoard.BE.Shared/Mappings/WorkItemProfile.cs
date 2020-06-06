using AutoMapper;
using FantasyScrumBoard.BE.Shared.Dto;
using FantasyScrumBoard.BE.Shared.Models;

namespace FantasyScrumBoard.BE.Shared.Mappings
{
    public class WorkItemProfile : Profile
    {
        public WorkItemProfile()
        {
            CreateMap<WorkItem, WorkItemDto>();
        }
    }
}
