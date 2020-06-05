using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyScrumBoard.BE.Shared.Models
{
    public class Sprint
    {
        public long Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EstimatedEndDate { get; set; }
        public DateTime? ClosedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Number { get; set; }

        public long ProjectId { get; set; }
        public long? MvpId { get; set; }

        public virtual Project Project { get; set; }
        public virtual User Mvp { get; set; }
        public virtual ICollection<WorkItem> WorkItems { get; set; }
    }
}
