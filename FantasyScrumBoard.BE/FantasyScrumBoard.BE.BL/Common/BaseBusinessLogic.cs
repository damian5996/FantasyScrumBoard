using AutoMapper;
using FantasyScrumBoard.BE.DataAccess;
using FantasyScrumBoard.BE.Shared.ViewModels;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FantasyScrumBoard.BE.BL.Common
{
    internal abstract class BaseBusinessLogic<TExecution, TResult> : BaseLogic<TExecution, TResult>
    {
        protected BaseBusinessLogic(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger) 
            : base(unitOfWork, mapper, logger)
        { }

        protected abstract Task<TExecution> ExecutionAsync();

        public async Task<ResultViewModel<TResult>> ExecuteAsync()
        {
            return await HandleExecutionAsync(async () => await ExecutionAsync());
        }
    }

    internal abstract class BaseBusinessLogic<TParam, TExecution, TResult> : BaseLogic<TExecution, TResult>
    {
        protected BaseBusinessLogic(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger) 
            : base(unitOfWork, mapper, logger)
        { }

        protected abstract IEnumerable<IValidator<TParam>> Validators { get; }

        protected abstract Task<TExecution> ExecutionAsync(TParam parameter);

        public async Task<ResultViewModel<TResult>> ExecuteAsync(TParam parameter)
        {
            return await HandleExecutionAsync(async () =>
            {
                foreach (var validator in Validators)
                {
                    validator.Validate(parameter);
                }

                return await ExecutionAsync(parameter);
            });
        }
    }
}
