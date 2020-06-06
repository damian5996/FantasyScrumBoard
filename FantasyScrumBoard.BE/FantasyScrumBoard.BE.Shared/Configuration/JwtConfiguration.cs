namespace FantasyScrumBoard.BE.Shared.Configuration
{
    public class JwtConfiguration
    {
        public bool RequireHttps { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Secret { get; set; }
        public int TokenValidHours { get; set; }
        public int RefreshTokenValidDays { get; set; }
    }
}
