using System.Threading.Tasks;
using FantasyScrumBoard.BE.BL.Sprint.Interfaces;
using FantasyScrumBoard.BE.Shared.BindingModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FantasyScrumBoard.BE.Controllers
{
    [Authorize]
    public class SprintController : BaseApiController
    {
        private readonly ISprintAddBusinessLogic _sprintAddBusinessLogic;

        public SprintController(ISprintAddBusinessLogic sprintAddBusinessLogic)
        {
            _sprintAddBusinessLogic = sprintAddBusinessLogic;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] SprintAddBindingModel sprintAddBindingModel)
        {
            if (!ModelState.IsValid)
            {
                return ModelStateError();
            }

            var result = await _sprintAddBusinessLogic.ExecuteAsync(sprintAddBindingModel);

            return CreateResponse(result);
        }
    }
}
