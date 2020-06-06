using System;
using System.Collections.Generic;
using FantasyScrumBoard.BE.Shared.Dto;
using FantasyScrumBoard.BE.Shared.Models;

namespace FantasyScrumBoard.BE.Shared.ViewModels
{
    public class SprintDetailsViewModel
    {
        public long Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EstimatedEndDate { get; set; }
        public DateTime? ClosedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Number { get; set; }

        public int Mvp { get; set; }
        public IEnumerable<WorkItem> WorkItems { get; set; }
    }
}
