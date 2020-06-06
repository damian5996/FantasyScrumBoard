using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FantasyScrumBoard.BE.BL.Common;
using FantasyScrumBoard.BE.DataAccess;
using FantasyScrumBoard.BE.Shared;
using FantasyScrumBoard.BE.Shared.BindingModels;
using FantasyScrumBoard.BE.Shared.Exceptions;

namespace FantasyScrumBoard.BE.BL.Sprint.Validator
{
    public class SprintExistenceValidator : IValidator<long>, IValidator<WorkItemAddBindingModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SprintExistenceValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Validate(long param)
        {
            ValidateSprintExistenceById(param);
        }

        public void Validate(WorkItemAddBindingModel param)
        {
            if (param.Sprint == null)
            {
                return;
            }
            ValidateSprintExistenceById((long)param.Sprint);
        }

        private void ValidateSprintExistenceById(long sprintId)
        {
            if (!_unitOfWork.Sprint.GetAll().Any(s => s.Id == sprintId))
            {
                throw new BusinessLogicException(string.Format(Constants.ErrorMessage.NotFoundTemplate,
                    nameof(_unitOfWork.Sprint), sprintId));
            }
        }
    }
}
