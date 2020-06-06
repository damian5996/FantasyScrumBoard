using FantasyScrumBoard.BE.BL.Common;
using FantasyScrumBoard.BE.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyScrumBoard.BE.BL.Project.Interfaces
{
    public interface IProjectGetDetailsBusinessLogic : IBusinessLogic<long, ProjectDetailsViewModel>
    {
    }
}
