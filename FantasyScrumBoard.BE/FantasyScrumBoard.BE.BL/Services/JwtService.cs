using FantasyScrumBoard.BE.BL.Services.Interfaces;
using FantasyScrumBoard.BE.Shared.Configuration;
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
using FantasyScrumBoard.BE.Shared;

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

        public JwtDto GenerateToken(UserDto userDto)
        {
            var jwtExpirationDate = DateTime.UtcNow.AddHours(_jwtConfiguration.TokenValidHours);
            return new JwtDto
            {
                Token = GetToken(userDto, false),
                RefreshToken = GetToken(userDto, true),
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

            var userDto = userId != null
                ? GetUser // test user
                : throw new UnauthorizedAccessException(Constants.ErrorMessage.InvalidRefreshToken);

            var jwtExpirationDate = DateTime.UtcNow.AddHours(_jwtConfiguration.TokenValidHours);
            
            return new JwtDto
            {
                Token = GetToken(userDto, false),
                RefreshToken = GetToken(userDto, true),
                ExpirationDate = jwtExpirationDate
            };
        }


        private SymmetricSecurityKey SecurityKey =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfiguration.Secret));

        private SymmetricSecurityKey RefreshTokenSecurityKey =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfiguration.Secret));

        private SigningCredentials Credentials(bool isRefresh) =>
            new SigningCredentials(isRefresh ? RefreshTokenSecurityKey : SecurityKey, SecurityAlgorithms.HmacSha256);

        private string GetToken(UserDto userDto, bool isRefresh, DateTime? expiration = null)
        {
            var token = new JwtSecurityToken(
                !isRefresh ? _jwtConfiguration.Issuer : null,
                !isRefresh ? _jwtConfiguration.Audience : null,
                claims: isRefresh ? RefreshTokenClaims(userDto.Id) : TokenClaims(userDto),
                expires: expiration ?? DateTime.UtcNow.AddHours(_jwtConfiguration.TokenValidHours),
                signingCredentials: Credentials(isRefresh));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private static IEnumerable<Claim> RefreshTokenClaims(long userId) => new[]
        {
            new Claim(ClaimTypes.Sid, userId.ToString()),
            new Claim(ClaimTypes.Hash, Guid.NewGuid().ToString())
        };

        private static IEnumerable<Claim> TokenClaims(UserDto userDto) => new[]
        {
            new Claim(ClaimTypes.Hash, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Sid, userDto.Id.ToString()),
            new Claim(ClaimTypes.Email, userDto.Email),
            new Claim(ClaimTypes.GivenName, userDto.FirstName),
            new Claim(ClaimTypes.Surname, userDto.LastName),
            new Claim(ClaimTypes.Name, userDto.Nick ?? string.Empty),
        };
    }
}
