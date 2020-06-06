using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyScrumBoard.BE.Shared.Configuration
{
    public class FacebookApiConfiguration
    {
        public string BaseUrl { get; set; }
        public string ValidateTokenMethodPathTemplate { get; set; }
        public string GetUserMethodPathTemplate { get; set; }
        public string AccessToken { get; set; }
        public string AppId { get; set; }
        public string AppSecret { get; set; }
    }
}
