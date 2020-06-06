using AutoMapper;
using FantasyScrumBoard.BE.DataAccess;
using FantasyScrumBoard.BE.Shared;
using FantasyScrumBoard.BE.Shared.Enums;
using FantasyScrumBoard.BE.Shared.Exceptions;
using FantasyScrumBoard.BE.Shared.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace FantasyScrumBoard.BE.BL.Common
{
    internal abstract class BaseLogic<TExecution, TResult>
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IMapper Mapper;
        private ILogger _logger;

        protected BaseLogic(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
            _logger = logger;
        }

        protected async Task<ResultViewModel<TResult>> HandleExecutionAsync(Func<Task<TExecution>> execution)
        {
            try
            {
                var result = await execution();

                return new ResultViewModel<TResult>
                {
                    Data = Mapper.Map<TResult>(result)
                };
            }
            catch (BusinessLogicException exception)
            {
                _logger.LogError(exception.Message);
                return new ResultViewModel<TResult>
                {
                    Error = exception.Message,
                    ExceptionType = exception.ExceptionType
                };
            }
            catch (UnauthorizedAccessException exception)
            {
                _logger.LogError(exception.Message);
                return new ResultViewModel<TResult>
                {
                    Error = Constants.ErrorMessage.Unauthorized,
                    ExceptionType = ExceptionType.Forbidden
                };
            }
            catch (Exception exception)
            {
                do
                {
                    _logger.LogError(exception.Message);
                    exception = exception.InnerException;
                } while (exception != null);

                return new ResultViewModel<TResult>
                {
                    Error = Constants.ErrorMessage.Default,
                    ExceptionType = ExceptionType.InternalServerError
                };
            }
        }
    }
}
