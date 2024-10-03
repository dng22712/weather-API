using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Weather.Models;
using Weather.Services;

namespace WeatherApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("{city}")]
        public async Task<IActionResult> GetWeather(string city)
        {
            var weatherData = await _weatherService.GetWeatherAsync(city);

            if (weatherData == null)
            {
                return NotFound("City not found or error fetching data.");
            }

            return Ok(weatherData);
        }
    }
}
