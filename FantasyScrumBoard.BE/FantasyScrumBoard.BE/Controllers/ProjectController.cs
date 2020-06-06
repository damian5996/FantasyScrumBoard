using FantasyScrumBoard.BE.BL.Project.Interfaces;
using FantasyScrumBoard.BE.Shared.BindingModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FantasyScrumBoard.BE.Controllers
{
    [Authorize]
    public class ProjectController : BaseApiController
    {
        private readonly IProjectAddBusinessLogic _projectAddBusinessLogic;
        private readonly IProjectGetListBusinessLogic _projectGetListBusinessLogic;

        public ProjectController(IProjectAddBusinessLogic projectAddBusinessLogic, IProjectGetListBusinessLogic projectGetListBusinessLogic)
        {
            _projectAddBusinessLogic = projectAddBusinessLogic;
            _projectGetListBusinessLogic = projectGetListBusinessLogic;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _projectGetListBusinessLogic.ExecuteAsync();

            return CreateResponse(result);
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
