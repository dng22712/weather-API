using System.Threading.Tasks;

using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IWeatherService
    {
        Task<WeatherData> GetWeatherAsync(string city);
    }
}
