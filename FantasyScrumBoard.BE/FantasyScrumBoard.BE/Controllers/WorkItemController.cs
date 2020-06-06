using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FantasyScrumBoard.BE.BL.WorkItem.Interfaces;
using FantasyScrumBoard.BE.Shared.BindingModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FantasyScrumBoard.BE.Controllers
{
    [Authorize]
    public class WorkItemController : BaseApiController
    {
        private readonly IWorkItemAddBusinessLogic _workItemAddBusinessLogic;

        public WorkItemController(IWorkItemAddBusinessLogic workItemAddBusinessLogic)
        {
            _workItemAddBusinessLogic = workItemAddBusinessLogic;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] WorkItemAddBindingModel workItemAddBindingModel)
        {
            if (!ModelState.IsValid)
            {
                return ModelStateError();
            }

            var result = await _workItemAddBusinessLogic.ExecuteAsync(workItemAddBindingModel);

            return CreateResponse(result);
        }
    }
}
