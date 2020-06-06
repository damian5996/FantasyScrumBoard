using AutoMapper;
using FantasyScrumBoard.BE.BL.Common;
using FantasyScrumBoard.BE.BL.Project.Interfaces;
using FantasyScrumBoard.BE.DataAccess;
using FantasyScrumBoard.BE.Shared.BindingModels;
using FantasyScrumBoard.BE.Shared.Dto;
using FantasyScrumBoard.BE.Shared.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FantasyScrumBoard.BE.BL.Project.Validators;
using FantasyScrumBoard.BE.BL.Services.Interfaces;

namespace FantasyScrumBoard.BE.BL.Project
{
    internal class ProjectAddBusinessLogic : BaseBusinessLogic<ProjectAddBindingModel, ProjectDto, ProjectViewModel>, IProjectAddBusinessLogic
    {
        private readonly ICurrentUserService _currentUserService;
        public ProjectAddBusinessLogic(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ProjectAddBusinessLogic> logger, ICurrentUserService currentUserService)
            : base(unitOfWork, mapper, logger)
        {
            _currentUserService = currentUserService;
        }

        protected override IEnumerable<IValidator<ProjectAddBindingModel>> Validators =>
            new IValidator<ProjectAddBindingModel>[]
            {
                new ProjectStartDateValidator()
            };

        protected override async Task<ProjectDto> ExecutionAsync(ProjectAddBindingModel parameter)
        {
            var projectDto = Mapper.Map<ProjectDto>(parameter);

            var currentUserId = _currentUserService.GetId();
            projectDto.ProjectMembers = new[] {new ProjectMemberDto {Id = currentUserId}};

            var projectId = await UnitOfWork.Project.InsertAsync(projectDto);

            return await UnitOfWork.Project.GetByIdAsync(projectId);
        }
    }
}
