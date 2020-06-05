using FantasyScrumBoard.BE.Shared;
using FantasyScrumBoard.BE.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FantasyScrumBoard.BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected IActionResult CreateResponse<T>(ResultViewModel<T> result)
        {
            if (result.IsValid)
            {
                return Ok(result.Data);
            }

            return result.ExceptionType != null
                ? StatusCode((int) result.ExceptionType, result.Error)
                : StatusCode(500, Constants.ErrorMessage.Fatal);
        }
    }
}
