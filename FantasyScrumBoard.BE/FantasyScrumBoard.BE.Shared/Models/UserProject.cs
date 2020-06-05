using FantasyScrumBoard.BE.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyScrumBoard.BE.Shared.Models
{
    public class UserProject
    {
        public long UserId { get; set; }
        public long ProjectId { get; set; }

        public virtual User User { get; set; }
        public virtual Project Project { get; set; }

        public ProjectRole Role { get; set; }
        public int Level { get; set; }
        public int Exp { get; set; }
        public bool IsOwner { get; set; }
    }
}
