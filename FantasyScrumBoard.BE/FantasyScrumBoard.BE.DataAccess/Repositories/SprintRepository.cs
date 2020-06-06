using AutoMapper;
using Castle.Core.Internal;
using FantasyScrumBoard.BE.DataAccess.Connection;
using FantasyScrumBoard.BE.DataAccess.Repositories.Interfaces;
using FantasyScrumBoard.BE.Shared;
using FantasyScrumBoard.BE.Shared.Dto;
using FantasyScrumBoard.BE.Shared.Enums;
using FantasyScrumBoard.BE.Shared.Exceptions;
using FantasyScrumBoard.BE.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FantasyScrumBoard.BE.DataAccess.Repositories
{
    public class SprintRepository : ISprintRepository
    {
        private readonly FantasyScrumBoardDbContext _db;
        private readonly IMapper _mapper;

        public SprintRepository(FantasyScrumBoardDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public IQueryable<SprintDto> GetAll()
        {
            return _mapper.ProjectTo<SprintDto>(_db.Sprint.AsQueryable());
        }

        public async Task<IEnumerable<SprintDto>> GetByProjectIdAsync(long projectId)
        {
            return _mapper.Map<IEnumerable<SprintDto>>(
                await _db.Sprint.Where(s => s.Project.Id == projectId).ToListAsync());
        }

        public async Task<long> InsertAsync(SprintDto sprintDto)
        {
            var sprint = _mapper.Map<Sprint>(sprintDto);
            sprint.CreatedAt = DateTime.UtcNow;
            sprint = await FillNavigationProperties(sprint, sprintDto);

            await _db.Sprint.AddAsync(sprint);
            await _db.SaveChangesAsync();

            return sprint.Id;
        }

        public async Task<SprintDto> GetByIdAsync(long sprintId)
        {
            return _mapper.Map<SprintDto>(await _db.Sprint.FindAsync(sprintId) 
                                         ?? throw new BusinessLogicException(
                                             string.Format(Constants.ErrorMessage.NotFoundTemplate,
                                                 nameof(_db.Sprint),
                                                 sprintId), ExceptionType.NotFound));
        }

        private async Task<Sprint> FillNavigationProperties(Sprint sprint, SprintDto sprintDto)
        {
            sprint.Project =
                await _db.Project.FindAsync(sprintDto.Project?.Id ?? 
                                            throw new BusinessLogicException(string.Format(
                                                Constants.ErrorMessage.IsRequiredTemplate, nameof(_db.Project)))) ??
                throw new BusinessLogicException(
                    string.Format(Constants.ErrorMessage.NotFoundTemplate,
                        nameof(_db.Project),
                        sprintDto.Project.Id), ExceptionType.NotFound);

            if (sprintDto.Mvp != null)
            {
                sprint.Mvp = await _db.User.FindAsync(sprintDto.Mvp.Id);
            }

            if (!sprintDto.WorkItems.IsNullOrEmpty())
            {
                foreach (var workItemDto in sprintDto.WorkItems)
                {
                    sprint.WorkItems.Add(await _db.WorkItem.FindAsync(workItemDto.Id) ??
                                         throw new BusinessLogicException(
                                             string.Format(Constants.ErrorMessage.NotFoundTemplate,
                                                 nameof(_db.WorkItem),
                                                 workItemDto.Id), ExceptionType.NotFound));
                }
            }

            return sprint;
        }
    }
}
