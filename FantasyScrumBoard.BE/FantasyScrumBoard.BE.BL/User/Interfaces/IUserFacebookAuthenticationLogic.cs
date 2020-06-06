using FantasyScrumBoard.BE.BL.Common;
using FantasyScrumBoard.BE.Shared.BindingModels;
using FantasyScrumBoard.BE.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyScrumBoard.BE.BL.User.Interfaces
{
    public interface IUserFacebookAuthenticationLogic : IBusinessLogic<FacebookLoginBindingModel, UserWithTokenViewModel>
    {
    }
}
