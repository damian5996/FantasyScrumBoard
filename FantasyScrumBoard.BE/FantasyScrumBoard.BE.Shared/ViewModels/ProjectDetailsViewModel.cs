using FantasyScrumBoard.BE.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyScrumBoard.BE.Shared.ViewModels
{
    public class ProjectDetailsViewModel : ProjectViewModel
    {
        public ICollection<SprintViewModel> Sprints { get; set; }
        public ICollection<ProjectMemberViewModel> Users { get; set; }
    }
}
