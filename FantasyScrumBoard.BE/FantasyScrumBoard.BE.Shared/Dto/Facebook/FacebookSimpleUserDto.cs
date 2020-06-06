using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace FantasyScrumBoard.BE.Shared.Dto.Facebook
{
    public class FacebookSimpleUserDto
    {
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
        [JsonPropertyName("is_valid")]
        public bool IsValidated { get; set; }
    }
}
