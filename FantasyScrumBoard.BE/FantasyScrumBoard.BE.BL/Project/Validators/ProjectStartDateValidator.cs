using FantasyScrumBoard.BE.BL.Common;
using FantasyScrumBoard.BE.Shared.BindingModels;
using FantasyScrumBoard.BE.Shared;
using FantasyScrumBoard.BE.Shared.Enums;
using FantasyScrumBoard.BE.Shared.Exceptions;
using System;

namespace FantasyScrumBoard.BE.BL.Project.Validators
{
    public class ProjectStartDateValidator : IValidator<ProjectAddBindingModel>
    {
        public void Validate(ProjectAddBindingModel param)
        {
            ValidateStartDate(param.StartDate);
        }

        private static void ValidateStartDate(DateTime startDate)
        {
            if (startDate < DateTime.UtcNow)
            {
                throw new BusinessLogicException(Constants.ErrorMessage.ProjectInvalidStartDate,
                    ExceptionType.BadRequest);
            }
        }
    }
}
