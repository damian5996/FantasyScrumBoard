using FantasyScrumBoard.BE.BL.Common;
using FantasyScrumBoard.BE.Shared.ViewModels;

namespace FantasyScrumBoard.BE.BL.Sprint.Interfaces
{
    public interface ISprintGetByIdBusinessLogic : IBusinessLogic<long, SprintDetailsViewModel>
    {
    }
}
