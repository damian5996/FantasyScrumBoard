using AutoMapper;
using FantasyScrumBoard.BE.DataAccess.Connection;
using FantasyScrumBoard.BE.DataAccess.Repositories.Interfaces;
using FantasyScrumBoard.BE.Shared;
using FantasyScrumBoard.BE.Shared.Dto;
using FantasyScrumBoard.BE.Shared.Enums;
using FantasyScrumBoard.BE.Shared.Exceptions;
using FantasyScrumBoard.BE.Shared.Extensions;
using FantasyScrumBoard.BE.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FantasyScrumBoard.BE.DataAccess.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly FantasyScrumBoardDbContext _db;
        private readonly IMapper _mapper;

        public ProjectRepository(FantasyScrumBoardDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<long> InsertAsync(ProjectDto projectDto)
        {
            var project = _mapper.Map<Project>(projectDto);
            project = await FillNavigationProperties(project, projectDto);

            await _db.Project.AddAsync(project);

            await _db.SaveChangesAsync();

            return project.Id;
        }

        public async Task<ProjectDto> GetByIdAsync(long projectId)
        {
            return _mapper.Map<ProjectDto>(await _db.Project.FindAsync(projectId) ??
                                           throw new BusinessLogicException(
                                               string.Format(Constants.ErrorMessage.NotFoundTemplate,
                                                   nameof(_db.Project), projectId), ExceptionType.BadRequest));
        }

        public async Task<IEnumerable<ProjectDto>> GetListByUserIdAsync(long userId)
        {
            var projects = await _db.Project.Where(x => x.UserProjects.Any(up => up.UserId == userId)).ToListAsync();

            return _mapper.Map<IEnumerable<ProjectDto>>(projects);
        }

        private async Task<Project> FillNavigationProperties(Project project, ProjectDto projectDto)
        {
            if (!projectDto.ProjectMembers.IsNullOrEmpty())
            {
                foreach (var projectMember in projectDto.ProjectMembers)
                {
                    project.UserProjects.Add(new UserProject
                    {
                        Project = project,
                        User = await _db.User.FindAsync(projectMember.Id) ?? throw new BusinessLogicException(
                                   string.Format(Constants.ErrorMessage.NotFoundTemplate, 
                                       nameof(_db.User), projectMember.Id), ExceptionType.BadRequest)
                    });
                }
            }

            if (!projectDto.Sprints.IsNullOrEmpty())
            {
                foreach (var sprint in projectDto.Sprints)
                {
                    project.Sprints.Add(await _db.Sprint.FindAsync(sprint.Id) ?? throw new BusinessLogicException(
                                            string.Format(Constants.ErrorMessage.NotFoundTemplate,
                                                nameof(_db.Sprint), sprint.Id), ExceptionType.BadRequest));
                }
            }

            if (!projectDto.WorkItems.IsNullOrEmpty())
            {
                foreach (var workItem in projectDto.WorkItems)
                {
                    project.WorkItems.Add(await _db.WorkItem.FindAsync(workItem.Id) ?? throw new BusinessLogicException(
                                              string.Format(Constants.ErrorMessage.NotFoundTemplate,
                                                  nameof(_db.WorkItem), workItem.Id), ExceptionType.BadRequest));
                }
            }

            return project;
        }
    }
}
