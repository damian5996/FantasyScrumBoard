using FantasyScrumBoard.BE.BL.Common;
using FantasyScrumBoard.BE.DataAccess;
using FantasyScrumBoard.BE.Shared;
using FantasyScrumBoard.BE.Shared.BindingModels;
using FantasyScrumBoard.BE.Shared.Enums;
using FantasyScrumBoard.BE.Shared.Exceptions;
using System.Linq;

namespace FantasyScrumBoard.BE.BL.Sprint.Validator
{
    public class SprintInProjectValidator : IValidator<WorkItemAddBindingModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SprintInProjectValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Validate(WorkItemAddBindingModel param)
        {
            if (param.Sprint != null)
            {
                ValidateSprintInProjectByIds((long)param.Sprint, param.Project);
            }
        }

        private void ValidateSprintInProjectByIds(long sprintId, long projectId)
        {
            var projectDto = _unitOfWork.Project.GetByIdAsync(projectId).Result;
            if (projectDto.Sprints.All(s => s.Id != sprintId))
            {
                throw new BusinessLogicException(
                    string.Format(Constants.ErrorMessage.SprintNotInProjectTemplate, sprintId, projectId),
                    ExceptionType.BadRequest);
            }
        }
    }
}
