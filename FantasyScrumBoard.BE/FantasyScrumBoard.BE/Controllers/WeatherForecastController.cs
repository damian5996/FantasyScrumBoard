using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FantasyScrumBoard.BE.BL.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FantasyScrumBoard.BE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        private readonly IJwtService _jwtService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IJwtService jwtService)
        {
            _logger = logger;
            _jwtService = jwtService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("token")]
        public IActionResult Token()
        {
            return Ok(_jwtService.GenerateToken(null));
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody]string refresh)
        {
            return Ok(await _jwtService.RefreshToken(refresh));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok();
        }
    }
}
