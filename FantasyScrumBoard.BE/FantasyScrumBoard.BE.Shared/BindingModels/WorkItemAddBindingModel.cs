using System.ComponentModel.DataAnnotations;

namespace FantasyScrumBoard.BE.Shared.BindingModels
{
    public class WorkItemAddBindingModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int StoryPoints { get; set; }
        public long? Sprint { get; set; }
        [Required]
        public long Project { get; set; }
    }
}
