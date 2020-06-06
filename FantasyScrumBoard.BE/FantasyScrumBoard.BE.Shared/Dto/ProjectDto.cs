using System;
using System.Collections.Generic;

namespace FantasyScrumBoard.BE.Shared.Dto
{
    public class ProjectDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? EditedAt { get; set; }

        public virtual IEnumerable<SprintDto> Sprints { get; set; }
        public virtual IEnumerable<WorkItemDto> WorkItems { get; set; }
        public virtual IEnumerable<ProjectMemberDto> ProjectMembers { get; set; }
    }
}
