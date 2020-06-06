using FantasyScrumBoard.BE.BL.Services.Interfaces;
using FantasyScrumBoard.BE.Shared.Configuration;
using FantasyScrumBoard.BE.Shared.Constants;
using FantasyScrumBoard.BE.Shared.Dto;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FantasyScrumBoard.BE.DataAccess;

namespace FantasyScrumBoard.BE.BL.Services
{
    public class JwtService : IJwtService
    {
        private readonly JwtConfiguration _jwtConfiguration;
        private readonly IUnitOfWork _unitOfWork;

        //to be deleted
        private UserDto GetUser => new UserDto
        {
            Id = 15,
            Email = "jan.kowalski@mail.com",
            FirstName = "Jan",
            LastName = "Kowalski",
            Nick = "jkowalski"
        };

        public JwtService(JwtConfiguration jwtConfiguration, IUnitOfWork unitOfWork)
        {
            _jwtConfiguration = jwtConfiguration;
            _unitOfWork = unitOfWork;
        }

        public JwtDto GenerateToken(UserDto user)
        {
            user = GetUser; //test
            var jwtExpirationDate = DateTime.UtcNow.AddHours(_jwtConfiguration.TokenValidHours);
            return new JwtDto
            {
                Token = GetToken(user, false),
                RefreshToken = GetToken(user, true),
                ExpirationDate = jwtExpirationDate
            };
        }

        public async Task<JwtDto> RefreshToken(string refreshToken)
        {
            ClaimsPrincipal claimsPrincipal;
            try
            {
                claimsPrincipal = new JwtSecurityTokenHandler().ValidateToken(refreshToken,
                    new TokenValidationParameters
                    {
                        ValidIssuer = _jwtConfiguration.Issuer,
                        ValidAudience = _jwtConfiguration.Audience,
                        IssuerSigningKey = RefreshTokenSecurityKey
                    }, out _);
            }
            catch (SecurityTokenExpiredException)
            {
                throw new UnauthorizedAccessException(Constants.ErrorMessage.ExpiredRefreshToken);
            }

            var userId = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid);

            var user = userId != null
                ? GetUser // test user
                : throw new UnauthorizedAccessException(Constants.ErrorMessage.InvalidRefreshToken);

            var jwtExpirationDate = DateTime.UtcNow.AddHours(_jwtConfiguration.TokenValidHours);
            
            return new JwtDto
            {
                Token = GetToken(user, false),
                RefreshToken = GetToken(user, true),
                ExpirationDate = jwtExpirationDate
            };
        }


        private SymmetricSecurityKey SecurityKey =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfiguration.Secret));

        private SymmetricSecurityKey RefreshTokenSecurityKey =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfiguration.Secret));

        private SigningCredentials Credentials(bool isRefresh) =>
            new SigningCredentials(isRefresh ? RefreshTokenSecurityKey : SecurityKey, SecurityAlgorithms.HmacSha256);

        private string GetToken(UserDto user, bool isRefresh, DateTime? expiration = null)
        {
            var token = new JwtSecurityToken(
                !isRefresh ? _jwtConfiguration.Issuer : null,
                !isRefresh ? _jwtConfiguration.Audience : null,
                claims: isRefresh ? RefreshTokenClaims(user.Id) : TokenClaims(user),
                expires: expiration ?? DateTime.UtcNow.AddHours(_jwtConfiguration.TokenValidHours),
                signingCredentials: Credentials(isRefresh));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private static IEnumerable<Claim> RefreshTokenClaims(long userId) => new[]
        {
            new Claim(ClaimTypes.Sid, userId.ToString()),
            new Claim(ClaimTypes.Hash, Guid.NewGuid().ToString())
        };

        private static IEnumerable<Claim> TokenClaims(UserDto user) => new[]
        {
            new Claim(ClaimTypes.Hash, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Sid, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.GivenName, user.FirstName),
            new Claim(ClaimTypes.Surname, user.LastName),
            new Claim(ClaimTypes.Name, user.Nick),
        };
    }
}
