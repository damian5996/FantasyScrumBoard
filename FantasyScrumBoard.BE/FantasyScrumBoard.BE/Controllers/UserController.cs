using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FantasyScrumBoard.BE.BL.User.Interfaces;
using FantasyScrumBoard.BE.Shared.BindingModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FantasyScrumBoard.BE.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly IUserFacebookAuthenticationLogic _userFacebookAuthenticationBusinessLogic;

        public UserController(IUserFacebookAuthenticationLogic userFacebookAuthenticationBusinessLogic)
        {
            _userFacebookAuthenticationBusinessLogic = userFacebookAuthenticationBusinessLogic;
        }

        [HttpPost("login/facebook")]
        public async Task<IActionResult> FacebookLoginAsync([FromBody] FacebookLoginBindingModel facebookLoginBindingModel)
        {
            var result = await _userFacebookAuthenticationBusinessLogic.ExecuteAsync(facebookLoginBindingModel);
            return CreateResponse(result);
        }
    }
}