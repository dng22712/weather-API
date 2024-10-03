using Weather.Services;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Weather.Models;


namespace Weather.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private const string apiKey = "d57d8a1f0f624d94b67142859242709"; // Replace with your Weather API key

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherData> GetWeatherAsync(string city)
        {
            // Get current weather
            var currentWeatherUrl = $"http://api.weatherapi.com/v1/current.json?key={apiKey}&q={city}";
            var response = await _httpClient.GetAsync(currentWeatherUrl);

            if (response.IsSuccessStatusCode)
            {
                var weatherData = await response.Content.ReadFromJsonAsync<dynamic>();
                var astronomyUrl = $"http://api.weatherapi.com/v1/astronomy.json?key={apiKey}&q={city}";
                var astronomyResponse = await _httpClient.GetAsync(astronomyUrl);

                if (astronomyResponse.IsSuccessStatusCode)
                {
                    var astronomyData = await astronomyResponse.Content.ReadFromJsonAsync<dynamic>();
                    return new WeatherData
                    {
                        City = weatherData.location.name,
                        Region = weatherData.location.region,
                        Country = weatherData.location.country,
                        LocalTime = weatherData.location.localtime,
                        Temperature = weatherData.current.temp_c,
                        Sunrise = astronomyData.astronomy.astro.sunrise,
                        Sunset = astronomyData.astronomy.astro.sunset
                    };
                }
            }

            return null;
        }
    }
}
