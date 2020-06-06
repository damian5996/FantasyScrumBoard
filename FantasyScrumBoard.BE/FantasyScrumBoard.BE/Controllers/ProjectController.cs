using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FantasyScrumBoard.BE.BL.Project.Interfaces;
using FantasyScrumBoard.BE.Shared.BindingModels;

namespace FantasyScrumBoard.BE.Controllers
{
    [Authorize]
    public class ProjectController : BaseApiController
    {
        private readonly IProjectAddBusinessLogic _projectAddBusinessLogic;

        public ProjectController(IProjectAddBusinessLogic projectAddBusinessLogic)
        {
            _projectAddBusinessLogic = projectAddBusinessLogic;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] ProjectAddBindingModel projectAddBindingModel)
        {
            if (!ModelState.IsValid)
            {
                return ModelStateError();
            }

            var result = await _projectAddBusinessLogic.ExecuteAsync(projectAddBindingModel);

            return CreateResponse(result);
        }
    }
}
