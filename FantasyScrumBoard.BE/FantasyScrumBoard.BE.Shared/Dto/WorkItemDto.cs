using System;
using System.Collections.Generic;
using FantasyScrumBoard.BE.Shared.Enums;
using FantasyScrumBoard.BE.Shared.Models;

namespace FantasyScrumBoard.BE.Shared.Dto
{
    public class WorkItemDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? EditedAt { get; set; }
        public WorkItemStatus Status { get; set; }
        public WorkItemType Type { get; set; }
        public int StoryPoints { get; set; }
        public Guid VersionGuid { get; set; }

        public SprintDto Sprint { get; set; }
        public ProjectDto Project { get; set; }
        public UserDto AssignedUser { get; set; }
        public IEnumerable<CommentDto> Comments { get; set; }
    }
}
