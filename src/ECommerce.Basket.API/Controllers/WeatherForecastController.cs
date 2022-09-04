using ECommerce.Basket.API.Models;
using ECommerce.Basket.Infrastructure.Redis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Basket.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ICacheService _cacheService;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ICacheService cacheService)
        { 
            _logger = logger;
            _cacheService = cacheService;
        }

        [HttpGet]
        public IActionResult Get(string key)
        {
           var user= _cacheService.Get<UserDto>(key);
            return Ok(user);
        }
        [HttpPost]
        public IActionResult  GetRedisServer([FromBody] UserDto userDto)
        {
            _cacheService.Add(userDto.Email, userDto);
            return Ok();
        }
    }
}
