using AutoMapper;
using FantasyScrumBoard.BE.BL.Common;
using FantasyScrumBoard.BE.BL.Sprint.Interfaces;
using FantasyScrumBoard.BE.DataAccess;
using FantasyScrumBoard.BE.Shared.Dto;
using FantasyScrumBoard.BE.Shared.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FantasyScrumBoard.BE.BL.Sprint.Validator;

namespace FantasyScrumBoard.BE.BL.Sprint
{
    internal class SprintCloseBusinessLogic : BaseBusinessLogic<long, SprintDto, SprintViewModel>, ISprintCloseBusinessLogic
    {
        public SprintCloseBusinessLogic(IUnitOfWork unitOfWork, IMapper mapper,
            ILogger<SprintCloseBusinessLogic> logger) : base(unitOfWork, mapper, logger)
        {
        }

        protected override IEnumerable<IValidator<long>> Validators => new IValidator<long>[]
        {
            new SprintExistenceValidator(UnitOfWork), 
        };
        protected override async Task<SprintDto> ExecutionAsync(long parameter)
        {
            var sprintDto = await UnitOfWork.Sprint.GetByIdAsync(parameter);
            sprintDto.ClosedAt = DateTime.UtcNow;

            await UnitOfWork.Sprint.UpdateAsync(sprintDto);
            await UnitOfWork.SaveAsync();

            return await UnitOfWork.Sprint.GetByIdAsync(sprintDto.Id);
        }
    }
}
