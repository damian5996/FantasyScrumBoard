using AutoMapper;
using FantasyScrumBoard.BE.BL.Common;
using FantasyScrumBoard.BE.BL.Project.Interfaces;
using FantasyScrumBoard.BE.BL.Project.Validators;
using FantasyScrumBoard.BE.DataAccess;
using FantasyScrumBoard.BE.Shared.Dto;
using FantasyScrumBoard.BE.Shared.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FantasyScrumBoard.BE.BL.Project
{
    internal class ProjectGetDetailsBusinessLogic : BaseBusinessLogic<long, ProjectDto, ProjectDetailsViewModel>, IProjectGetDetailsBusinessLogic
    {
        public ProjectGetDetailsBusinessLogic(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ProjectGetDetailsBusinessLogic> logger) : base(unitOfWork, mapper, logger)
        {
        }

        protected override IEnumerable<IValidator<long>> Validators =>
            new IValidator<long>[]
            {
                new ProjectExistenceValidator(UnitOfWork)
            };

        protected override async Task<ProjectDto> ExecutionAsync(long projectId)
        {
            var project = await UnitOfWork.Project.GetByIdAsync(projectId);
            return project;
        }
    }
}
