using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FantasyScrumBoard.BE.BL.Common;
using FantasyScrumBoard.BE.BL.Project.Validators;
using FantasyScrumBoard.BE.BL.Sprint.Interfaces;
using FantasyScrumBoard.BE.DataAccess;
using FantasyScrumBoard.BE.Shared.BindingModels;
using FantasyScrumBoard.BE.Shared.Dto;
using FantasyScrumBoard.BE.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FantasyScrumBoard.BE.BL.Sprint
{
    internal class SprintAddBusinessLogic : BaseBusinessLogic<SprintAddBindingModel, SprintDto, SprintViewModel>, ISprintAddBusinessLogic
    {
        public SprintAddBusinessLogic(IUnitOfWork unitOfWork, IMapper mapper, ILogger<SprintAddBusinessLogic> logger) :
            base(unitOfWork, mapper, logger)
        {
        }

        protected override IEnumerable<IValidator<SprintAddBindingModel>> Validators =>
            new IValidator<SprintAddBindingModel>[]
            {
                new ProjectExistenceValidator(UnitOfWork),
            };
        protected override async Task<SprintDto> ExecutionAsync(SprintAddBindingModel parameter)
        {
            var sprintDto = Mapper.Map<SprintDto>(parameter);

            var sprints = (await UnitOfWork.Sprint.GetByProjectIdAsync(parameter.Project)).ToList();
            sprintDto.Number = sprints.Any() ? sprints.Max(s => s.Number) + 1 : 1;

            var sprintId = await UnitOfWork.Sprint.InsertAsync(sprintDto);

            return await UnitOfWork.Sprint.GetByIdAsync(sprintId);
        }
    }
}
