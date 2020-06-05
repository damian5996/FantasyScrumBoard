using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyScrumBoard.BE.Shared.Models
{
    public class UserAchievement
    {
        public long UserId { get; set; }
        public long AchievementId { get; set; }

        public virtual User User { get; set; }
        public virtual Achievement Achievement { get; set; }

        public DateTime EarnedDate { get; set; }
    }
}
