using AutoMapper;
using FantasyScrumBoard.BE.Shared.Dto;
using FantasyScrumBoard.BE.Shared.Models;

namespace FantasyScrumBoard.BE.Shared.Mappings
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<CommentDto, Comment>()
                .ForMember(dest => dest.WorkItem, opt => opt.Ignore())
                .ForMember(dest => dest.Author, opt => opt.Ignore());
            CreateMap<Comment, CommentDto>();
        }
    }
}
