using AutoMapper;
using FantasyScrumBoard.BE.BL.Common;
using FantasyScrumBoard.BE.BL.Project.Interfaces;
using FantasyScrumBoard.BE.BL.Services.Interfaces;
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
    internal class ProjectGetListBusinessLogic : BaseBusinessLogic<IEnumerable<ProjectDto>, IEnumerable<ProjectViewModel>>, IProjectGetListBusinessLogic
    {
        private readonly ICurrentUserService _currentUserService;
        public ProjectGetListBusinessLogic(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ProjectAddBusinessLogic> logger, ICurrentUserService currentUserService)
            : base(unitOfWork, mapper, logger)
        {
            _currentUserService = currentUserService;
        }

        protected override async Task<IEnumerable<ProjectDto>> ExecutionAsync()
        {
            var currentUserId = _currentUserService.GetId();
            return await UnitOfWork.Project.GetListByUserIdAsync(currentUserId);
        }
    }
}
