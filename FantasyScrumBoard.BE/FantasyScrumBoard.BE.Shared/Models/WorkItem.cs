using FantasyScrumBoard.BE.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyScrumBoard.BE.Shared.Models
{
    public class WorkItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EditedAt { get; set; }
        public WorkItemStatus Status { get; set; }
        public WorkItemType Type { get; set; }
        public int StoryPoints { get; set; }
        public Guid VersionGuid { get; set; }


        public long? SprintId { get; set; }
        public long ProjectId { get; set; }
        public long AssignedUserId { get; set; }

        public virtual Sprint Sprint { get; set; }
        public virtual Project Project { get; set; }
        public virtual User AssignedUser{ get; set; }
    }
}
