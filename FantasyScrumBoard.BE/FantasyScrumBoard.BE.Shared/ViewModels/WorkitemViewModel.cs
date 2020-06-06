using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyScrumBoard.BE.Shared.ViewModels
{
    public class WorkItemViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long? SprintId { get; set; }
        public long ProjectId { get; set; }
        public UserViewModel AssignedUser { get; set; }
    }
}
