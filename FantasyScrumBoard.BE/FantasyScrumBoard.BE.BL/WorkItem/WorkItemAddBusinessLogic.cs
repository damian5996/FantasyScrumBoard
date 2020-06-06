using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FantasyScrumBoard.BE.BL.Common;
using FantasyScrumBoard.BE.BL.Project.Validators;
using FantasyScrumBoard.BE.BL.Sprint.Validator;
using FantasyScrumBoard.BE.BL.WorkItem.Interfaces;
using FantasyScrumBoard.BE.DataAccess;
using FantasyScrumBoard.BE.Shared.BindingModels;
using FantasyScrumBoard.BE.Shared.Dto;
using FantasyScrumBoard.BE.Shared.Enums;
using FantasyScrumBoard.BE.Shared.ViewModels;
using Microsoft.Extensions.Logging;

namespace FantasyScrumBoard.BE.BL.WorkItem
{
    internal class WorkItemAddBusinessLogic : BaseBusinessLogic<WorkItemAddBindingModel, WorkItemDto, WorkItemViewModel>, IWorkItemAddBusinessLogic
    {
        public WorkItemAddBusinessLogic(IUnitOfWork unitOfWork, IMapper mapper, ILogger<WorkItemAddBusinessLogic> logger) : base(unitOfWork, mapper, logger)
        {
        }

        protected override IEnumerable<IValidator<WorkItemAddBindingModel>> Validators =>
            new IValidator<WorkItemAddBindingModel>[]
            {
                new ProjectExistenceValidator(UnitOfWork),
                new SprintExistenceValidator(UnitOfWork),
                new SprintInProjectValidator(UnitOfWork), 
            };
        protected override async Task<WorkItemDto> ExecutionAsync(WorkItemAddBindingModel parameter)
        {
            var workItemDto = Mapper.Map<WorkItemDto>(parameter);
            workItemDto.Status = WorkItemStatus.ToDo;
            workItemDto.Type = WorkItemType.Task;

            var workItemId = await UnitOfWork.WorkItem.InsertAsync(workItemDto);
            return await UnitOfWork.WorkItem.GetByIdAsync(workItemId);
        }
    }
}
