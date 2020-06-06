using FantasyScrumBoard.BE.BL.Common;
using FantasyScrumBoard.BE.Shared.BindingModels;
using FantasyScrumBoard.BE.Shared.ViewModels;

namespace FantasyScrumBoard.BE.BL.WorkItem.Interfaces
{
    public interface IWorkItemAddBusinessLogic : IBusinessLogic<WorkItemAddBindingModel, WorkItemViewModel>
    {
    }
}
