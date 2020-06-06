using AutoMapper;
using FantasyScrumBoard.BE.BL.Common;
using FantasyScrumBoard.BE.BL.Project.Interfaces;
using FantasyScrumBoard.BE.BL.Project.Validators;
using FantasyScrumBoard.BE.DataAccess;
using FantasyScrumBoard.BE.Shared.Dto;
using FantasyScrumBoard.BE.Shared.ViewModels;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FantasyScrumBoard.BE.BL.Project
{
    internal class ProjectGetDetailsBusinessLogic : BaseBusinessLogic<long, ProjectNoLoadingDto, ProjectDetailsViewModel>, IProjectGetDetailsBusinessLogic
    {
        public ProjectGetDetailsBusinessLogic(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ProjectGetDetailsBusinessLogic> logger) : base(unitOfWork, mapper, logger)
        {
        }

        protected override IEnumerable<IValidator<long>> Validators =>
            new IValidator<long>[]
            {
                new ProjectExistenceValidator(UnitOfWork)
            };

        protected override async Task<ProjectNoLoadingDto> ExecutionAsync(long projectId)
        {
            var project = await UnitOfWork.Project.GetByIdNoLoadingAsync(projectId);
            //project.Sprints = await UnitOfWork.Sprint.GetByProjectIdAsync(project.Id);
            
            return project;
        }
    }
}
