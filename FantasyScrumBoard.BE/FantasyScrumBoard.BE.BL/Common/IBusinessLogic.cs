using FantasyScrumBoard.BE.Shared.ViewModels;
using System.Threading.Tasks;

namespace FantasyScrumBoard.BE.BL.Common
{
    public interface IBusinessLogic<in TParam, TResult>
    {
        Task<ResultViewModel<TResult>> ExecuteAsync(TParam parameter);
    }

    public interface IBusinessLogic<TResult>
    {
        Task<ResultViewModel<TResult>> ExecuteAsync();
    }
}
