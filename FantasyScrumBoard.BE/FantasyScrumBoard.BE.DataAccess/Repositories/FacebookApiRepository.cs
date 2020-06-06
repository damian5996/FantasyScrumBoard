using FantasyScrumBoard.BE.DataAccess.Repositories.Interfaces;
using FantasyScrumBoard.BE.Shared.Configuration;
using FantasyScrumBoard.BE.Shared.Dto.Facebook;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FantasyScrumBoard.BE.DataAccess.Repositories
{
    public class FacebookApiRepository : IFacebookApiRepository
    {
        private readonly FacebookApiConfiguration _facebookApiConfiguration;

        public FacebookApiRepository(FacebookApiConfiguration facebookApiConfiguration)
        {
            _facebookApiConfiguration = facebookApiConfiguration;
        }

        public async Task<bool> ValidateTokenAsync(string authToken)
        {
            var url = _facebookApiConfiguration.BaseUrl + string.Format(
                          _facebookApiConfiguration.ValidateTokenMethodPathTemplate, authToken,
                          _facebookApiConfiguration.AccessToken);

            using var httpClient = new HttpClient { BaseAddress = new Uri(_facebookApiConfiguration.BaseUrl) };

            var result = await httpClient.GetAsync(url);

            result.EnsureSuccessStatusCode();

            var facebookResult = await JsonSerializer.DeserializeAsync<FacebookRequestResultDto<FacebookSimpleUserDto>>(await result.Content.ReadAsStreamAsync());

            return facebookResult.Content.IsValidated;
        }

        public async Task<FacebookUserDto> GetUserInfoAsync(string authToken)
        {
            var url = _facebookApiConfiguration.BaseUrl +
                      string.Format(_facebookApiConfiguration.GetUserMethodPathTemplate, authToken);

            url = AddAccessProof(url, authToken);

            using var httpClient = new HttpClient { BaseAddress = new Uri(_facebookApiConfiguration.BaseUrl) };

            var result = await httpClient.GetAsync(url);
            var test = await result.Content.ReadAsStringAsync();
            result.EnsureSuccessStatusCode();

            var facebookUserDto =
                await JsonSerializer.DeserializeAsync<FacebookUserDto>(
                    await result.Content.ReadAsStreamAsync());

            return facebookUserDto;
        }

        private string AddAccessProof(string url, string authToken)
        {
            return $"{url}&appsecret_proof={GetFacebookAppSecretProof(authToken)}";
        }

        private string GetFacebookAppSecretProof(string authToken)
        {
            var keyBytes = Encoding.UTF8.GetBytes(_facebookApiConfiguration.AppSecret);
            var messageBytes = Encoding.UTF8.GetBytes(authToken);

            using var sha256 = new HMACSHA256(keyBytes);

            var hash = sha256.ComputeHash(messageBytes);


            var sbHash = new StringBuilder();
            foreach (var c in hash)
            {
                sbHash.Append(c.ToString("x2"));
            }
            return sbHash.ToString();
        }
    }
}
