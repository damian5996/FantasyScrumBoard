using System;

namespace FantasyScrumBoard.BE.Shared.Dto
{
    public class JwtDto
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
