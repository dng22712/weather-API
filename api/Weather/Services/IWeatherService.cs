using System.Threading.Tasks;
using Weather.Models; // Assuming you have a WeatherModel class here

namespace Weather.Services
{
    public interface IWeatherService
    {
        Task<WeatherData> GetWeatherAsync(string city);
    }

}
