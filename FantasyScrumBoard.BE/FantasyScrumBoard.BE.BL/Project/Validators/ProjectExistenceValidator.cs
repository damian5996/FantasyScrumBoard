using System.Linq;
using FantasyScrumBoard.BE.BL.Common;
using FantasyScrumBoard.BE.DataAccess;
using FantasyScrumBoard.BE.Shared;
using FantasyScrumBoard.BE.Shared.BindingModels;
using FantasyScrumBoard.BE.Shared.Exceptions;

namespace FantasyScrumBoard.BE.BL.Project.Validators
{
    public class ProjectExistenceValidator : IValidator<SprintAddBindingModel>, IValidator<long>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectExistenceValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Validate(SprintAddBindingModel param)
        {
            Validate(param.Project);
        }

        public void Validate(long projectId)
        {
            if (!_unitOfWork.Project.GetAll().Any(p => p.Id == projectId))
            {
                throw new BusinessLogicException(string.Format(Constants.ErrorMessage.NotFoundTemplate,
                    nameof(_unitOfWork.Project), projectId));
            }
        }
    }
}
