using System;
using System.ComponentModel.DataAnnotations;

namespace FantasyScrumBoard.BE.Shared.BindingModels
{
    public class SprintAddBindingModel
    {
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EstimatedEndDate { get; set; }
        [Required]
        public long Project { get; set; }
    }
}
