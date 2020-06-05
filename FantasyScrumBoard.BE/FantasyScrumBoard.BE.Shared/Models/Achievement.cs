using FantasyScrumBoard.BE.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyScrumBoard.BE.Shared.Models
{
    public class Achievement
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public AchievementType Type { get; set; }
    }
}
