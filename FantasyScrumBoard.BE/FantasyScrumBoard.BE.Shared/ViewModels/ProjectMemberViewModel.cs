using System;
using System.Collections.Generic;
using System.Text;
using FantasyScrumBoard.BE.Shared.Enums;

namespace FantasyScrumBoard.BE.Shared.ViewModels
{
    public class ProjectMemberViewModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int ProjectLevel { get; set; }
        public string Nick { get; set; }
        public int ProjectExp { get; set; }
        public ProjectRole Role { get; set; }
        public bool IsOwner { get; set; }
    }
}
