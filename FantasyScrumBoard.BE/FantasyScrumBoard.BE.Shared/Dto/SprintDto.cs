using System;
using System.Collections.Generic;
using FantasyScrumBoard.BE.Shared.Models;

namespace FantasyScrumBoard.BE.Shared.Dto
{
    public class SprintDto
    {
        public long Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EstimatedEndDate { get; set; }
        public DateTime? ClosedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Number { get; set; }

        public ProjectDto Project { get; set; }
        public UserDto Mvp { get; set; }
        public IEnumerable<WorkItemDto> WorkItems { get; set; }
    }
}
