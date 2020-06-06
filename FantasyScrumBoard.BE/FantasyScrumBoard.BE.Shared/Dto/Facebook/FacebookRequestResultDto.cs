using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace FantasyScrumBoard.BE.Shared.Dto.Facebook
{
    public class FacebookRequestResultDto<T>
    {
        [JsonPropertyName("data")]
        public T Content { get; set; }
    }
}
