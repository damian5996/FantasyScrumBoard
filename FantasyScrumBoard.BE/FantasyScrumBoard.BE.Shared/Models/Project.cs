using System;
using System.Collections.Generic;

namespace FantasyScrumBoard.BE.Shared.Models
{
    public class Project
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? EditedAt { get; set; }

        public virtual ICollection<Sprint> Sprints { get; set; } = new HashSet<Sprint>();
        public virtual ICollection<WorkItem> WorkItems { get; set; } = new HashSet<WorkItem>();
        public virtual ICollection<UserProject> UserProjects { get; set; } = new HashSet<UserProject>();
    }
}
