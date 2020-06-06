using System;
using System.ComponentModel.DataAnnotations;

namespace FantasyScrumBoard.BE.Shared.BindingModels
{
    public class ProjectAddBindingModel
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        [Required]
        [StringLength(512)]
        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
    }
}
