using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FantasyScrumBoard.BE.Shared.BindingModels
{
    public class FacebookLoginBindingModel
    {
        [Required]
        public string Token { get; set; }
    }
}
