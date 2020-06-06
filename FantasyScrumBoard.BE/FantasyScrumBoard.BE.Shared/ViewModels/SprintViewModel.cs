using System;

namespace FantasyScrumBoard.BE.Shared.ViewModels
{
    public class SprintViewModel
    {
        public long Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EstimatedEndDate { get; set; }
        public DateTime? ClosedAt { get; set; }
        public int Number { get; set; }
    }
}
