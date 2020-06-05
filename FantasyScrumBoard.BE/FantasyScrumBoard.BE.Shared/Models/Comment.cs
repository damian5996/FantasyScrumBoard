using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyScrumBoard.BE.Shared.Models
{
    public class Comment
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? EditedAt { get; set; }

        public long AuthorId { get; set; }
        public long WorkItemId { get; set; }

        public virtual User Author { get; set; }
        public virtual WorkItem WorkItem { get; set; }
    }
}
