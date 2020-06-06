using AutoMapper;
using FantasyScrumBoard.BE.BL.Common;
using FantasyScrumBoard.BE.BL.Sprint.Interfaces;
using FantasyScrumBoard.BE.BL.Sprint.Validator;
using FantasyScrumBoard.BE.DataAccess;
using FantasyScrumBoard.BE.Shared.Dto;
using FantasyScrumBoard.BE.Shared.ViewModels;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FantasyScrumBoard.BE.BL.Sprint
{
    internal class SprintGetByIdBusinessLogic : BaseBusinessLogic<long, SprintDto, SprintDetailsViewModel>, ISprintGetByIdBusinessLogic
    {
        public SprintGetByIdBusinessLogic(IUnitOfWork unitOfWork, IMapper mapper, ILogger<SprintGetByIdBusinessLogic> logger) : base(unitOfWork, mapper, logger)
        {
        }

        protected override IEnumerable<IValidator<long>> Validators => new IValidator<long>[]
        {
            new SprintExistenceValidator(UnitOfWork), 
        };
        protected override async Task<SprintDto> ExecutionAsync(long parameter)
        {
            return await UnitOfWork.Sprint.GetByIdAsync(parameter);
        }
    }
}
