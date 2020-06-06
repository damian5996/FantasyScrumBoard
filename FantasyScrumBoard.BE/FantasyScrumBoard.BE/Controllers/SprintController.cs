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
        private readonly ISprintCloseBusinessLogic _sprintCloseBusinessLogic;

        public SprintController(ISprintAddBusinessLogic sprintAddBusinessLogic, ISprintCloseBusinessLogic sprintCloseBusinessLogic)
        {
            _sprintAddBusinessLogic = sprintAddBusinessLogic;
            _sprintCloseBusinessLogic = sprintCloseBusinessLogic;
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

        [HttpPut("{id}/close")]
        public async Task<IActionResult> CloseSprintAsync([FromRoute] long id)
        {
            var result = await _sprintCloseBusinessLogic.ExecuteAsync(id);

            return CreateResponse(result);
        }
    }
}
