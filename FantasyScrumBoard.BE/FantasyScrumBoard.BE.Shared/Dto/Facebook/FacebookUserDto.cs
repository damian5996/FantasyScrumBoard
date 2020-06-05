using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace FantasyScrumBoard.BE.Shared.Dto.Facebook
{
    public class FacebookUserDto
    {
        [JsonPropertyName("id")]
        public string FacebookId { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("birthday")]
        public string BirthDate { get; set; }
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }
        [JsonPropertyName("middle_name")]
        public string MiddleNames { get; set; }
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }
    }
}
