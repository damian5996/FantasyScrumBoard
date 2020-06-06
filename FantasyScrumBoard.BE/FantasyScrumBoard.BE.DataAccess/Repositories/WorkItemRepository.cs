using System;
using System.Threading.Tasks;
using AutoMapper;
using FantasyScrumBoard.BE.DataAccess.Connection;
using FantasyScrumBoard.BE.DataAccess.Repositories.Interfaces;
using FantasyScrumBoard.BE.Shared;
using FantasyScrumBoard.BE.Shared.Dto;
using FantasyScrumBoard.BE.Shared.Enums;
using FantasyScrumBoard.BE.Shared.Exceptions;
using FantasyScrumBoard.BE.Shared.Models;

namespace FantasyScrumBoard.BE.DataAccess.Repositories
{
    public class WorkItemRepository : IWorkItemRepository
    {
        private readonly FantasyScrumBoardDbContext _db;
        private readonly IMapper _mapper;

        public WorkItemRepository(FantasyScrumBoardDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<long> InsertAsync(WorkItemDto workItemDto)
        {
            var workItem = _mapper.Map<WorkItem>(workItemDto);
            workItem.CreatedAt = DateTime.UtcNow;
            workItem = await FillNavigationProperties(workItem, workItemDto);

            await _db.WorkItem.AddAsync(workItem);
            await _db.SaveChangesAsync();

            return workItem.Id;
        }

        public async Task<WorkItemDto> GetByIdAsync(long id)
        {
            return _mapper.Map<WorkItemDto>(await _db.WorkItem.FindAsync(id) ?? throw new BusinessLogicException(
                                                string.Format(Constants.ErrorMessage.NotFoundTemplate,
                                                    nameof(_db.WorkItem),
                                                    id), ExceptionType.NotFound));
        }

        private async Task<WorkItem> FillNavigationProperties(WorkItem workItem, WorkItemDto workItemDto)
        {
            if (workItemDto.Sprint != null)
            {
                workItem.Sprint = await _db.Sprint.FindAsync(workItemDto.Sprint.Id) ??
                                  throw new BusinessLogicException(
                                      string.Format(Constants.ErrorMessage.NotFoundTemplate, nameof(_db.Sprint),
                                          workItemDto.Sprint.Id), ExceptionType.NotFound);
            }

            workItem.Project = await _db.Project.FindAsync(workItemDto.Project?.Id ??
                                                           throw new BusinessLogicException(
                                                               string.Format(Constants.ErrorMessage.IsRequiredTemplate,
                                                                   nameof(_db.Project)), ExceptionType.BadRequest)) ??
                               throw new BusinessLogicException(
                                   string.Format(Constants.ErrorMessage.NotFoundTemplate, nameof(_db.Project),
                                       workItemDto.Project.Id), ExceptionType.NotFound);

            if (workItemDto.AssignedUser != null)
            {
                workItem.AssignedUser = await _db.User.FindAsync(workItemDto.AssignedUser.Id) ??
                                  throw new BusinessLogicException(
                                      string.Format(Constants.ErrorMessage.NotFoundTemplate, nameof(_db.User),
                                          workItemDto.AssignedUser.Id), ExceptionType.NotFound);
            }

            if (workItemDto.Comments != null)
            {
                foreach (var commentDto in workItemDto.Comments)
                {
                    workItem.Comments.Add(await _db.Comment.FindAsync(commentDto.Id) ??
                                          throw new BusinessLogicException(
                                              string.Format(Constants.ErrorMessage.NotFoundTemplate, nameof(_db.Comment),
                                                  commentDto.Id), ExceptionType.NotFound));
                }
            }

            return workItem;
        }
    }
}
